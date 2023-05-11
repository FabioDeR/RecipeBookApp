import { Cut } from "../data/Cut";
import { BaseResponse } from "./BaseResponse";

export class CreateCutResponse extends BaseResponse {
  cutDto: Cut | undefined;
}
