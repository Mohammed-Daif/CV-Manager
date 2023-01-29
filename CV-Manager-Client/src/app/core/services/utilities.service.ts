import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root',
})
export class UtilitiesService {
  constructor(private messageService: MessageService) {}
  showMessage(
    summary: string,
    detail: string,
    type: 'success' | 'info' | 'error' | 'warn'
  ) {
    this.messageService.add({
      severity: type,
      summary,
      detail,
    });
  }
}
