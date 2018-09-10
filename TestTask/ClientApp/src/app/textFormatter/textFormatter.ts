import { Component, Input } from '@angular/core';

@Component({
  selector: 'text-formatter',
  templateUrl: 'textFormatter.html',
  styles: ['']
})
export class TextFormatter {
  @Input() ckeditorContent: string;
  isEditDescription: boolean = true;
  edit() {
    this.isEditDescription = !this.isEditDescription;
  }
  getData() {
    console.log(CKEDITOR.instances);
    this.ckeditorContent = CKEDITOR.instances.editor1.getData();
  }
}
