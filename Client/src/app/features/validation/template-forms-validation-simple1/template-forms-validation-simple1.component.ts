import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { LookupItem } from 'src/app/_models/LookupItem';
import { Person } from 'src/app/_models/person';
import { PeopleService } from 'src/app/_services/people.service';

@Component({
  selector: 'app-forms-validation-simple1',
  templateUrl: './template-forms-validation-simple1.component.html',
  styleUrls: ['./template-forms-validation-simple1.component.css']
})
export class TemplateFormsValidationSimple1Component implements OnInit {
  person: Person | null = null;
  stateList: LookupItem[] = [];
  @ViewChild('editForm') editForm!: NgForm;

  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editForm.dirty){
      $event.returnValue = true;
    }
 }

  constructor(private route: ActivatedRoute,
    private peopleService: PeopleService) { }

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.stateList = data['states'];
    });

    let id = +this.route.snapshot.params['id'];
    this.updatePerson(id);
  }


  updateMember() {
    console.log(this.editForm)
  }

  createPerson() {
    this.person = new Person();
  }

  updatePerson(id: number) {
     if (id == undefined) id = 1;
     this.peopleService.getById(id).pipe(take(1)).subscribe(person => {
       this.person = person;
       if (this.editForm){
        this.editForm.reset(person);
       }
      });

  }


}
