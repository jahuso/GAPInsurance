import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PoliciesComponent } from '../pages/policies/policies.component';
import { Policy } from '../models/policy';

@Injectable({
  providedIn: 'root'
})
export class PoliciesService {

  formData: PoliciesComponent;
  policiesURL = 'http://localhost:51458/api/policies/';
  lista: any[];

  constructor(private http: HttpClient) { 
    console.log('Policies Service Listo');
  }

  getPolicies() {
    return this.http.get(this.policiesURL);
  }

  getPolicy(key$: string) {
    return this.http.get(`${this.policiesURL}${ key$}`);
  }

  refreshPolicies(){
    this.http.get(this.policiesURL)
    .toPromise()
      .then((res:any) => {
      this.lista=res;
      console.log(this.lista);
    });
 }

  postPolicy( policy: Policy ) {
    const reqHeader = new HttpHeaders().set('Content-Type', 'application/json')
       .set('Accept', 'application/json');
    return this.http.post(this.policiesURL, policy,  { headers: reqHeader });
  }

  putPolicy(key$: string, policy: Policy ) {
    const reqHeader = new HttpHeaders().set('Content-Type', 'application/json')
       .set('Accept', 'application/json');
    return this.http.put(`${this.policiesURL}${ key$}`, policy,  { headers: reqHeader });
  }

  deletePolicy(key$: string){
    const reqHeader = new HttpHeaders().set('Content-Type', 'application/json')
       .set('Accept', 'application/json');
    return this.http.delete (`${this.policiesURL}${ key$}`, { headers: reqHeader });
  }
}
