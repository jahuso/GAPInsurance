import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './login/register.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PagenotfoundComponent } from './shared/pagenotfound/pagenotfound.component';
import { PagesComponent } from './pages/pages.component';
import { PoliciesComponent } from './pages/policies/policies.component';
import { CustomersComponent } from './pages/customers/customers.component';
import { PolicyComponent } from './pages/policies/policy.component';
import { CustomerComponent } from './pages/customers/customer.component';

import { AuthGuardService } from './services/auth-guard.service';







const appRoutes: Routes = [
    { path: '',
        component: PagesComponent,
        children:[
            { path: 'dashboard', component: DashboardComponent },
            { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
                //Management
            { 
                path: 'policies',
                component: PoliciesComponent,
                canActivate: [AuthGuardService]
            },
            { path: 'policy/:id', component: PolicyComponent },
            { path: 'customers', component: CustomersComponent },
            { path: 'customer/:id', component: CustomerComponent },
        ]
     },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: '**', component: PagenotfoundComponent }
];

export const APP_ROUTES = RouterModule.forRoot( appRoutes, { useHash: true});
