import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormOfOwnerShips, Genders, LegalStatuses } from 'src/app/Constants/Enums';
import { CommonData } from 'src/app/models/CommonData';
import { NewInvestmentPermitService } from 'src/app/services/newinvestmentpermit.services';



@Component({
  selector: 'app-new-investment-permit-application-form',
  templateUrl: './new-investment-permit-application-form.component.html',
  styleUrls: ['./new-investment-permit-application-form.css']
})
export class NewInvestmentPermitApplicationFormComponent implements OnInit {
  NUMERIC_REGEX = new RegExp(/^[0-9]+$/);
  private tinValidators = [
    Validators.required,
    Validators.minLength(4),
    Validators.maxLength(10),
    Validators.pattern(this.NUMERIC_REGEX),
  ];
  PHONE_VALIDATOR = new RegExp(
    /^(?!0+$)(?:\(?\+\d{1,3}\)?[- ]?|0)?\d{10}$/
  );
  investmentPermitForm: FormGroup;
  showGeneralExpansion = true;
  showAddressExpansion = true;
  nationality: any[] = [];

  Id: number=0;
  address: any=null;
  Regions: any[] = [];
  zones: any[] = [];
  Weredas: any[] = [];
  Kebeles: any[] = [];
  FormOfOwnerShip: number=1;
  filteredZones: any[] = [];
  filteredWeredas: any[] = [];
  filteredKebeles: any[] = [];
  filteredRegions: any[] = [];
  AllowCascading = true;
  Nationalities: any;
  Genders: any[]=[];
  LegalStatuses: any[]=[];
  FormOfOwnerShips: any[]=[];
  filteredKebelles: any[]=[];

  constructor(
      private formBuilder: FormBuilder
     , private  newInvestmentPermitService: NewInvestmentPermitService
  ) {

    this.investmentPermitForm = this.formBuilder.group({
      FormOfOwnerShip: [0], // remove
      PersonalInformationId:[0],
      Tin: ["",Validators.compose(this.tinValidators,)], 
      RegistrationNumber: [
        "",Validators.compose([Validators.required, Validators.maxLength(8)])],
     TradeName: ["", Validators.compose([Validators.required])],
     IsOpenedDocumentBeforeNow: [ false,Validators.compose([ Validators.required,]),
    ],
    BusinessOrganizationId:[0],

      FirstName: [""],
      FatherName: [
        ""
      ],
      GrandName: [
        ""
      ],
      Gender: [
        0,
        Validators.compose([
          Validators.required
        ]),
      ],
      Nationality: [
        ""
      ],
   
     Region: ["", Validators.compose([Validators.required])],
     Zone: ["", Validators.compose([Validators.required])],
     Woreda: ["", Validators.compose([Validators.required])],
     Kebelle: ["", Validators.compose([Validators.required])],
     HouseNo: ["", Validators.compose([Validators.required])],
     Country: ["", Validators.compose([Validators.required])],
     OtherAdress: ["", Validators.compose([Validators.required, ]),],
     Telephone: [
      "",
      Validators.compose([
        Validators.required,
        Validators.pattern(this.PHONE_VALIDATOR),
      ]), ],
    
    Fax:["" ],
     Email: ["", Validators.compose([Validators.email, Validators.maxLength(40)])],
     Pobox: [
      "" ],
    
    
      BusinessOrganizationName: ["", Validators.compose([Validators.required])],
      LegalStatus: ["", Validators.compose([Validators.required])],
     
    
    });

 
   }
  
  
  ngOnInit(): void {
    this.Lookups();
    this.getConstants();
  }
  compareIds(id1: any, id2: any): boolean {
   return true;
  }
  assesmentMethod(event:any){
    console.log(event);
    
    this.FormOfOwnerShip = event;

  }

  private Lookups() {
    this.getRegions();
    this.getAllZones();
    this.getAllWeredas();
    this.getNationalitys();
    this.getAllKebeles();
  }

  get PersonalInformationId() {
    return this.investmentPermitForm.get("PersonalInformationId");
  }
  get  BusinessOrganizationId() {
    return this.investmentPermitForm.get("BusinessOrganizationId");
  }

  get FirstName() {
    return this.investmentPermitForm.get("FirstName");
  }
 
  get FatherName() {
    return this.investmentPermitForm.get("FatherName");
  }
  get TradeName() {
    return this.investmentPermitForm.get("TradeName");
  }
  get BusinessOrganizationName() {
    return this.investmentPermitForm.get("BusinessOrganizationName");
  }
  get Nationality() {
    return this.investmentPermitForm.get("Nationality");
  }
  

  get GrandName() {
    return this.investmentPermitForm.get("GrandName");
  }
  get RegistrationNumber() {
    return this.investmentPermitForm.get("RegistrationNumber");
  }


  get Tin() {
    return this.investmentPermitForm.get("Tin");
  }
get  IsOpenedDocumentBeforeNow(){
  return this.investmentPermitForm.get("IsOpenedDocumentBeforeNow");
}
 
  get LegalStatus() {
    return this.investmentPermitForm.get("LegalStatus");
  }

  get Region() {
    return this.investmentPermitForm.get("Region");
  }

  get Zone() {
    return this.investmentPermitForm.get("Zone");
  }

  get Woreda() {
    return this.investmentPermitForm.get("Woreda");
  }
  get Country() {
    return this.investmentPermitForm.get("Country");
  }
  get Kebelle() {
    return this.investmentPermitForm.get("Kebelle");
  }
  get  OtherAdress() {
    return this.investmentPermitForm.get("OtherAdress");
  }

  get HouseNo() {
    return this.investmentPermitForm.get("HouseNo");
  }

  get Gender() {
    return this.investmentPermitForm.get("Gender");
  }
 

  get Fax() {
    return this.investmentPermitForm.get("Fax");
  }
get Email(){
  return this.investmentPermitForm.get("Email");
}
  get Pobox() {
    return this.investmentPermitForm.get("Pobox");
  }


  get Telephone() {
    return this.investmentPermitForm.get("Telephone");
  }

  getRegions() {
    this.newInvestmentPermitService.
        getRegions()
          .subscribe((res) => {
            this.Regions=res;
          });
  
  }
  getNationalitys() {
    this.newInvestmentPermitService.
    getNationalitys()
      .subscribe((res) => {
        this.nationality=res;
      });

  }

  getAllZones() {
    this.newInvestmentPermitService.
    getZones()
      .subscribe((res) => {
        this.zones=res;
      });
    
  }

  getAllWeredas() {
    this.newInvestmentPermitService.
    getWeredas()
      .subscribe((res) => {
        this.Weredas=res;
      });
 
  }
  getAllKebeles() {
    this.newInvestmentPermitService.
    getKebeles()
      .subscribe((res) => {
        this.Kebeles=res;
      });
 
  }

 filterRegion(RegionIdentificationCode: String) {
  
    if (!RegionIdentificationCode || !this.AllowCascading) {
      return;
    }
 if (!this.zones) {
      return;
    }
   

    this.filteredZones = this.zones.filter((item) => {
      return item.parentIdentifactionCode == RegionIdentificationCode;
    });
    console.log(this.filteredZones);

   }
   filterZone(zoneIdentificationCode: String) {
    if (!zoneIdentificationCode || !this.AllowCascading) {
      return;
    }
    this.filteredWeredas = this.Weredas.filter((item) => {
      return item.parentIdentifactionCode === zoneIdentificationCode;
    });
  }

   filterWereda(WeredaIdentificationCode: string) {
    if (!WeredaIdentificationCode || !this.AllowCascading) {
      return;
    }
    this.filteredKebelles = this.Kebeles.filter((item) => {
      return item.parentIdentifactionCode === WeredaIdentificationCode;
    });
  }

 
  private getConstants() {
   
    let gender:CommonData  = new CommonData ();
    Genders.forEach((pair) => {
      gender = {
        Id: pair.Id.toString(),
        Description: pair.Description,
      };
      this.Genders.push(gender);
    });

    let legalstatus: CommonData  = new CommonData ();
    LegalStatuses.forEach((pair) => {
      legalstatus = {
        Id: pair.Id.toString(),
        Description: pair.Description ,
      };
      this.LegalStatuses.push(legalstatus);
    });
    let formofownerships:CommonData = new CommonData();
    FormOfOwnerShips.forEach((pair) => {
      formofownerships = {
        Id: pair.Id.toString(),
        Description:pair.Description,
      };
      this.FormOfOwnerShips.push(formofownerships);
    });
   
 
    

 


  }
   
  
     public addForm() {
     
        this.newInvestmentPermitService.
        addInvetmentPermitForm(this.investmentPermitForm.value)
          .subscribe((res) => {
    
        
          });
    
      
      }
    

}
