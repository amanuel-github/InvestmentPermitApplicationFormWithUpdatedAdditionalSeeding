import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class NewInvestmentPermitService {

  constructor(private httpClient: HttpClient) { }
   BASE_URI = "http://localhost:58474/api/";
   
  addInvetmentPermitForm(data:any) {
    
    const PersonalInformation = {} as any;
    const BusinessOrganization = {} as any;
    const OwnerData = {} as any;
    OwnerData.FormOfOwnerShip=data.FormOfOwnerShip.toString();
    OwnerData.Tin=data.Tin;
    OwnerData.RegistrationNumber=data.RegistrationNumber;
    OwnerData.TradeName=data.TradeName;
    OwnerData.IsOpenedDocumentBeforeNow=data.IsOpenedDocumentBeforeNow;

    PersonalInformation.FirstName=data.FirstName;
    PersonalInformation.FatherName=data.FatherName;
    PersonalInformation.GrandName=data.GrandName;
    PersonalInformation.Gender=data.Gender.toString();
    PersonalInformation.Nationality=data.Nationality;
    PersonalInformation.Region=data.Region;
    PersonalInformation.Zone=data.Zone;
    PersonalInformation.Woreda=data.Woreda;
    PersonalInformation.Kebelle=data.Kebelle;
    PersonalInformation.HouseNo=data.HouseNo;
    PersonalInformation.Country=data.Country;
    PersonalInformation.Email=data.Email;
    PersonalInformation.OtherAdress=data.OtherAdress;
    PersonalInformation.Telephone=data.Telephone;
    PersonalInformation.Fax=data.Fax;
    PersonalInformation.Pobox=data.Pobox;

    BusinessOrganization.BusinessOrganizationName=data.BusinessOrganizationName;
    BusinessOrganization.LegalStatus=data.LegalStatus.toString();
    OwnerData.PersonalInformation=PersonalInformation;
    OwnerData.BusinessOrganization=BusinessOrganization;
 
    return this.httpClient.post<any>(this.BASE_URI+'InvestmentPermissionControllers',OwnerData);
  }
  getKebeles() {
    
    return this.httpClient.get<any[]>(this.BASE_URI+'KebelleControllers');
  }
  getWeredas() {
   
    return this.httpClient.get<any[]>(this.BASE_URI+'WoredaControllers');
  }
  getZones() {
   
    return this.httpClient.get<any[]>(this.BASE_URI+'ZoneControllers');
  }
  getRegions() {

    return this.httpClient.get<any[]>(this.BASE_URI+'RegionControllers');
  }
  getNationalitys() {
  
    return this.httpClient.get<any>(this.BASE_URI+'NationalityControllers' );
  }
}