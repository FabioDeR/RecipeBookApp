import { Variety } from "../data/Variety";
import { BaseResponse } from "./BaseResponse";

export class CreateVarietyResponse extends BaseResponse {
  varietyDto: Variety | undefined;
}
