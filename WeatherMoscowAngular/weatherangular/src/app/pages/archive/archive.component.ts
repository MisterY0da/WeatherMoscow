import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { ArchiveService } from '../../shared/services/archive.service';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-archive',
  standalone: true,
  imports: [CommonModule, NgxDropzoneModule, MatButtonModule],
  templateUrl: './archive.component.html',
  styleUrl: './archive.component.scss'
})
export class ArchiveComponent {
  constructor(private archiveService: ArchiveService) {}
  files: File[] = [];

  uploaded: boolean = false;

  onSelect(event: any) {
    console.log(event);
    this.files.push(...event.addedFiles);
    this.files.forEach(element => {
      console.log(`file name: ${element.name}`);
    });
  }
  
  onRemove(event: any) {
    console.log(event);
    this.files.splice(this.files.indexOf(event), 1);
  }

  uploadFiles() {
    this.files.forEach(element => {
      console.log(`uploading file: ${element.name}`)
    });
    this.archiveService.sendFiles(this.files);
    this.uploaded = true;
  }
}