import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvestmentpermitRoutingModule } from './investmentpermit-routing.module';
import { MaterialModule } from '../material-modules/material.module';
import { NewInvestmentPermitApplicationFormComponent } from './new-investment-permit-application-form/new-investment-permit-application-form.component';
import { NewInvestmentPermitService } from '../services/newinvestmentpermit.services';


@NgModule({
  declarations: [NewInvestmentPermitApplicationFormComponent],
  imports: [
    CommonModule,
    InvestmentpermitRoutingModule,
    MaterialModule

  ],
  providers: [ NewInvestmentPermitService],

})
export class InvestmentpermitModule { }
