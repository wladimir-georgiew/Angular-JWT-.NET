import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { RequestHandlerService } from 'src/app/services/request-handler.service';
import { CreateCategoryRequest } from 'src/app/_interfaces/Admin/Categories/CreateCategoryRequest.model';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css']
})

export class CreateCategoryComponent {
  createForm: FormGroup;
  errorMessage: string = '';
  showError: boolean;

  constructor(private requestHandlerService: RequestHandlerService){ }

  ngOnInit(): void {
    this.createForm = new FormGroup({
      categoryName: new FormControl(''),
    });
  }

  public CreateCategory = (category: CreateCategoryRequest) => {
    this.requestHandlerService.HttpPost('categories/add', category)
    .subscribe({
      next: (createdCategoryId: number) => {
        this.showError = false;
      },
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.message;
        this.showError = true;
      }
    });
  }
}
