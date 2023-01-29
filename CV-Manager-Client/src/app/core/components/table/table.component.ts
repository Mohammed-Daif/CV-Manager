import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TableModule } from 'primeng/table';
import { IPagination } from './pagination.interface';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { PaginatorModule } from 'primeng/paginator';

@Component({
  standalone: true,
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
  imports: [
    TableModule,
    CommonModule,
    ToolbarModule,
    ButtonModule,
    PaginatorModule,
  ],
})
export class TableComponent {
  _entities: IPagination | undefined;
  @Input() set entities(value: IPagination) {
    this._entities = value;
    console.log({ value });
  }
  _cols: any[] = [];
  @Input() set cols(value: any[]) {
    console.log({ value });
    this._cols = value;
  }
  @Output() onView = new EventEmitter<any>();
  @Output() onEdit = new EventEmitter<any>();
  @Output() onDelete = new EventEmitter<any>();
  @Output() onNew = new EventEmitter<any>();
  @Output() onPaginate = new EventEmitter<any>();
  
}
