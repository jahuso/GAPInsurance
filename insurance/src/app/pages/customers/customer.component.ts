import { Component, OnInit } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { Customer } from 'src/app/models/customer';
import { Router, ActivatedRoute } from '@angular/router';
import { CustomersService } from 'src/app/services/customers.service';
import { PoliciesService } from '../../services/policies.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styles: []
})
export class CustomerComponent {

  forma: FormGroup;

  customer: Customer = {
    id: '',
    documentId: '',
    name: '',
    policyId: ''
  }

  new:boolean = false;
  id: any;
  polizas:any[]=[];



  constructor(private customersService: CustomersService, private policiesService: PoliciesService,
              private router: Router,
              private route: ActivatedRoute )
              {
                this.route.params
                .subscribe( parametros => {
                  this.id = parametros['id'];
                  this.customersService.getCustomer(this.id)
                      .subscribe( res => {
                        this.customer = res;
                        this.policiesService.getPolicies()
                        .subscribe((data: any) => {
                            this.polizas = data;
                            console.log(this.polizas);
                      },
                      err => {
                        console.log(err);
                      }
                    );
                    })
    });
  }

  linkPolicy(forma: NgForm){
    console.log(this.id);
    forma.value['id'] = this.id;
      this.customersService.putCustomer(this.id, forma.value)
        .subscribe( data => {
        },
        error => {
          console.log(error);
        });
  }
}
