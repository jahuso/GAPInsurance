import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CustomersComponent } from '../pages/customers/customers.component';
import { Customer } from '../models/customer'

@Injectable({
  providedIn: 'root'
})

export class CustomersService {

  formData: CustomersComponent;
  customersURL = 'http://localhost:51458/api/customers/';
  lista: any[];

  constructor(private http: HttpClient) { 
    console.log('Customers Service Listo');
  }

  getCustomers() {
    return this.http.get(this.customersURL);
  }

  getCustomer(key$: string) {
    return this.http.get(`${this.customersURL}${ key$}`);
  }

  putCustomer(key$: string, customer: Customer ) {
    const reqHeader = new HttpHeaders().set('Content-Type', 'application/json')
       .set('Accept', 'application/json');
    return this.http.put(`${this.customersURL}${ key$}`, customer,  { headers: reqHeader });
  }
}
