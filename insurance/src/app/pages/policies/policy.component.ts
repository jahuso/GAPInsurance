import { Component, OnInit } from '@angular/core';
import { Policy } from 'src/app/models/policy';
import { FormGroup, NgForm } from '@angular/forms';
import { PoliciesService } from '../../services/policies.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styles: []
})
export class PolicyComponent {

  forma: FormGroup;

  policy: Policy = {
    id: '',
    name: '',
    description: '',
    coverageType: '',
    coverage: '',
    vigencyStart: '',
    coveragePeriod: '',
    price: '',
    riskType: ''
  }

  new:boolean = false;
  id: any;
  errorMessage: string;

  constructor(private policiesService: PoliciesService,
              private router: Router,
              private route: ActivatedRoute ) {


    this.route.params
      .subscribe( parametros => {
        this.id = parametros['id'];
        if (this.id !== 'new' ) {
          this.policiesService.getPolicy(this.id)
            .subscribe( res => {
              this.policy = res;
            },
            err => {              
              console.log(err);
            }
          );
        }
    });
  }

  addNew(forma: NgForm){
    this.router.navigate(['/policy', 'new']);
    forma.reset();
  }

  createPolicy(forma: NgForm){
    console.log(this.id);
    if (this.id =='new') {
      this.policiesService.postPolicy(forma.value)
    .subscribe(
      res => {
        this.resetForm(forma);
        this.errorMessage=null;
      },
      error => {
        this.errorMessage=error["error"]
      }
    );
    } else{
      forma.value['id'] = this.id;
      this.policiesService.putPolicy(this.id, forma.value)
        .subscribe( data => {
          this.resetForm(forma);
          this.errorMessage=null;
        },
        error => {
          this.errorMessage=error["error"]
        });
    }
  }

  resetForm(form?: NgForm) {
    form.resetForm();
  }
}
