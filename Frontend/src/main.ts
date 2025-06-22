import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';
import { TodoComponent } from './app/components/todo.component';

bootstrapApplication(TodoComponent, appConfig)
  .catch((err) => console.error(err));
