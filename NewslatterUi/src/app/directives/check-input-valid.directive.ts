import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appCheckInputValid]'
})
export class CheckInputValidDirective {

  @Input() appCheckInputValid :HTMLInputElement;
  constructor(
    private _el:ElementRef<HTMLInputElement>
  ) { }

  @HostListener("keyup") keyup(){
    this._el.nativeElement.className="";
    if(this.appCheckInputValid.validity.valid){
      this._el.nativeElement.className="form-control is-valid"
    }else{
      this._el.nativeElement.className="form-control is-invalid"
    }
  }

}
