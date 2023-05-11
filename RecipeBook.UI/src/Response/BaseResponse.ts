export class BaseResponse {
  success: boolean = true;
  message: string  = "";
  validationErrors: string[]  = [];
}
