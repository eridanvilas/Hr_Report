import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FileToUpdateComponent } from './views/file-to-update/file-to-update.component';
import { HomeComponent } from './views/home/home.component';
import { RelatorioComponent } from './views/relatorio/relatorio.component';

const routes: Routes = [{
  path: "",
  component: HomeComponent
},
{
  path: "relatorio",
  component: RelatorioComponent
},
{
 path:"fileupload",
 component: FileToUpdateComponent
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
