import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { FormsValidationSimple1Component } from '../features/validation/forms-validation-simple1/forms-validation-simple1.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesFormExampleGuard implements CanDeactivate<unknown> {

  canDeactivate(component: FormsValidationSimple1Component): boolean  {
    if (component.editForm.dirty){
      return confirm('Are you sure you want to continue?  Any unsaved changes will be lost!')
    }

    return true;
  }

}
