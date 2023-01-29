import { UtilitiesService } from 'src/app/core/services/utilities.service';
import { CvApiService } from './../../cv-api.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormArray,
  Validators,
  FormControl,
} from '@angular/forms';
import { ICV } from '../../cv.interface';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Route } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cv-form',
  templateUrl: './cv-form.component.html',
  styleUrls: ['./cv-form.component.scss'],
})
export class CvFormComponent implements OnInit, OnDestroy {
  form: FormGroup;
  NewCvForm: boolean = true;
  id: any;
  ref: Subscription | undefined;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private cvApiService: CvApiService,
    private utilitiesService: UtilitiesService
  ) {
    this.form = this.fb.group({
      cityName: [''],
      email: [''],
      fullName: ['', Validators.required],
      mobileNumber: ['', Validators.required],
      name: ['', Validators.required],
      experienceInfoList: new FormArray([
        this.fb.group({
          id: [],
          companyName: new FormControl('', [
            Validators.required,
            Validators.maxLength(20),
          ]),
          companyWorkField: ['', Validators.required],
          cityName: [''],
        }),
      ]),
    });
  }

  async ngOnInit() {
    this.renderForm();
  }
  async renderForm() {
    this.NewCvForm = this.activeRoute.snapshot.url.find(
      (s) => s.path == 'create'
    )
      ? true
      : false;
    if (!this.NewCvForm) {
      this.id = this.activeRoute.snapshot.paramMap.get('id');
      this.ref = this.cvApiService.getGetById<ICV>(this.id).subscribe((res) => {
        console.log({ res });
        this.form = this.fb.group({
          cityName: [res.cityName],
          email: [res.email],
          fullName: [res.fullName, Validators.required],
          mobileNumber: [res.mobileNumber, Validators.required],
          name: [res.name, Validators.required],

          experienceInfoList: this.fb.array(
            res.experienceInfoList.map((e) => {
              console.log({ e });
              const fg = this.fb.group({
                id: [e.id],
                companyName: [
                  e.companyName,
                  [Validators.required, Validators.maxLength(20)],
                ],
                companyWorkField: [e.companyWorkField, Validators.required],
                cityName: [e.cityName],
              });
              return fg;
            })
          ),
        });
      });
    }
  }
  ngOnDestroy(): void {
    this.ref?.unsubscribe();
  }
  experiencesArray() {
    return <FormArray>this.form?.get('experienceInfoList');
  }
  onSubmit() {
    this.form.markAllAsTouched();
    this.form.markAsTouched();
    this.form.markAsDirty();
    this.experiencesArray().controls.forEach((control) => {
      control.markAllAsTouched();
      control.markAsTouched();
      control.markAsDirty();
    });
    if (this.form?.valid) {
      if (this.NewCvForm) {
        this.cvApiService
          .post(this.form.value)
          .subscribe((res) => this.handelResponse(res));
      } else {
        this.cvApiService
          .Put(this.form.value, this.id)
          .subscribe((res) => this.handelResponse(res));
      }
    }
    console.log(this.form, this.form?.value, this.form?.valid);
  }
  handelResponse(res: any) {
    if (this.NewCvForm)
      this.utilitiesService.showMessage(
        'Created',
        'Item Created successfully',
        'success'
      );
    else
      this.utilitiesService.showMessage(
        'Updated',
        'Item updated successfully',
        'success'
      );

    this.router.navigate(['cv']);
  }
  addNewSection() {
    const innerFormArray = <FormArray>this.form?.controls['experienceInfoList'];

    innerFormArray?.controls.push(
      this.fb.group({
        id: [],
        companyName: [, [Validators.required, Validators.maxLength(20)]],
        companyWorkField: [, Validators.required],
        cityName: [],
      })
    );
    
    this.form.registerControl('experienceInfoList', innerFormArray);
  }
  deleteSection(index: number) {
    (<FormArray>this.form?.controls['experienceInfoList'])?.controls.splice(
      index,
      1
    );
  }
  toFormGroup(form: any): FormGroup {
    return <FormGroup>form;
  }
}
