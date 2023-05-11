import { Gamme } from "../data/Gamme";
import { BaseResponse } from "./BaseResponse";

export class CreateGammeResponse extends BaseResponse {
  gammeDto: Gamme | undefined;
}
