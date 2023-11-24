import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ArchiveComponent } from './pages/archive/archive.component';
import { WeatherTableComponent } from './pages/weather-table/weather-table.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'app/dashboard',
        pathMatch: 'full'
    },
    {
        path: '',
        component: AppComponent,
        children: [
            {
                path: 'app/dashboard',
                component: DashboardComponent
            },
            {
                path: 'app/weatherTable',
                component: WeatherTableComponent
            },
            {
                path: 'app/archive',
                component: ArchiveComponent
            }
        ]
    }
];
