import { Component,OnInit,ChangeDetectorRef } from "@angular/core";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TodoService } from "../services/todo.service";
import { Todo } from "../models/todo.model";

@Component(
    {
        selector:'app-todo',
        standalone: true,
        imports: [CommonModule, FormsModule],
        templateUrl: './todo.component.html'
    }
)

export class TodoComponent implements OnInit
{
    todos:Todo[] = [];
    newTodo: Todo = {name:'',isComplete:false};

    constructor(private todoService:TodoService,private cd: ChangeDetectorRef){}

    ngOnInit(): void {
        this.loadTodos();
    }

    loadTodos() {
    this.todoService.getTodos().subscribe(data => {
      this.todos = [...data];   
      this.cd.detectChanges();
    });
  }

    addTodo()
    {
        this.todoService.addTodo(this.newTodo).subscribe(()=>{
            this.newTodo = {name:'',isComplete:false}
            this.loadTodos();
        });
    }

    updateTodo(todo:Todo)
    {
        if(todo.id)
        {
            this.todoService.updateTodo(todo.id,todo).subscribe(()=>this.loadTodos());
        }
    }

    deleteTodo(id:string)
    {
        this.todoService.deleteTodo(id).subscribe(()=>this.loadTodos());
    }
}