import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})

export class ArchiveService {
    constructor(private http: HttpClient) {}

    sendFiles(files: File[]) {
        files.forEach(file => {
            const formData = new FormData();
            formData.append('file', file)
            this.http.post('https://localhost:5001/api/weatherrecord/add', formData).subscribe();
        })
    }
}