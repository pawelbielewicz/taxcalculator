import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Product } from './product';
import { ProductService } from './product.service';

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
  product: Product;
  products: Array<Product> = [];

  constructor(private formbulider: FormBuilder, private productService: ProductService) { }

  ngOnInit() {
    this.product = new Product();
    this.productForm = new FormGroup({
      prodName: new FormControl(''),
      prodPrice: new FormControl(''),
      prodQuantity: new FormControl(''),
      prodVat: new FormControl(''),
    });
    this.loadAllVats();
  }

  loadAllVats() {
    this.allVats = this.productService.getAllVats();
  }

  onFormSubmit() {
    this.dataSaved = false;
    this.product.Name = this.productForm.value.prodName;
    this.product.Price = this.productForm.value.prodPrice;
    this.product.Quantity = this.productForm.value.prodQuantity;
    this.product.VatType = this.productForm.value.prodVat;

    this.products.push(this.product);
    this.CalculateProducts(this.products);
    this.productForm.reset();
  }

  CalculateProducts(products: Product[]) {
    this.productService.calculateGrossPrice(products).subscribe(
      () => {
        this.dataSaved = true;
        this.massage = 'Record saved Successfully';
        this.productForm.reset();
      }
    )
  }

  resetForm() {
    this.productForm.reset();
    this.massage = null;
    this.dataSaved = false;
  }

}
