import { Component } from '@angular/core';
import { Customer } from 'src/app/models/customer';
import { CustomersService } from '../../services/customers.service';
             


@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styles: []
})
export class CustomersComponent {

  customers: Customer[] = [];
  loading: boolean = true;

  constructor(private customerService: CustomersService){
    this.customerService.getCustomers()
    .subscribe((data: any) => {
        this.customers = data;
        this.loading= false;
        console.log(this.customers);
    });
  }

}
