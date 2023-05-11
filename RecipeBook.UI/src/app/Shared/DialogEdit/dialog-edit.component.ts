import { Component, Inject } from '@angular/core';
import { Category } from '../../../data/Category';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-edit',
  templateUrl: './dialog-edit.component.html',
  styleUrls: ['./dialog-edit.component.css']
})
export class DialogEditComponent {
  constructor(
    public dialogRef: MatDialogRef<DialogEditComponent>,
    @Inject(MAT_DIALOG_DATA) public category: Category,
  ) { }


  onNoClick(): void {
    this.dialogRef.close();
  }
}
