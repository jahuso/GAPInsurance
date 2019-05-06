import { Component } from '@angular/core';
import { Policy } from 'src/app/models/policy';
import { PoliciesService } from '../../services/policies.service';

@Component({
  selector: 'app-policies',
  templateUrl: './policies.component.html',
  styles: []
})
export class PoliciesComponent {

  policies: Policy[] = [];
  loading: boolean = true;

  constructor(private policiesService: PoliciesService){
    this.policiesService.getPolicies()
    .subscribe((data: any) => {
        this.policies = data;
        this.loading= false;
        console.log(this.policies);
    });
  }

  deletePolicy(key$: string){
    this.policiesService.deletePolicy(key$)
      .subscribe( (data:any) => {
        if (data) {
          this.policies=data;
          this.policiesService.refreshPolicies();
        }else{        
          console.error(data);
        }
      })
  }

}
