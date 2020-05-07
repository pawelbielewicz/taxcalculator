import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ProductService } from './product.service';
import { Product } from './product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {

  dataSaved = false;
  productForm: any;
  allVats: Observable<string[]>;
  productIdUpdate = null;
  massage = null;

  constructor(private formbulider: FormBuilder, private productService: ProductService) { }

  ngOnInit() {
    this.productForm = this.formbulider.group({
      Name: ['', [Validators.required]],
      Price: ['', [Validators.required]],
      Quantity: ['', [Validators.required]],
      VatName: ['', [Validators.required]]
    });
    this.loadAllVats();
  }

  loadAllVats() {
    this.allVats = this.productService.getAllVats();
  }


}
