import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewInvestmentPermitApplicationFormComponent } from './new-investment-permit-application-form/new-investment-permit-application-form.component';

const routes: Routes = [
  {
    path: '',
    component:NewInvestmentPermitApplicationFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvestmentpermitRoutingModule { }
