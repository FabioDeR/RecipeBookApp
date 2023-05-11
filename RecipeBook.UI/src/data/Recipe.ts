export class Recipe { 
  name: string = "";
  quantity: number = 0;
  comment: string = "";
  cultureId: string = "";
  productId: string | unknown;
  unitId: string = "";
  cutId: string = "";
  internalValidation: Date = new Date();
  externalValidation: Date = new Date();
  productName: string | null = "";
  unitName: string = "";
}
