import { HttpClient } from "@angular/common/http";
import { Injectable} from "@angular/core";
import { Observable } from "rxjs";
import { Todo } from "../models/todo.model";

@Injectable(
    {
        providedIn:'root'
    }
)

export class TodoService
{
    private baseUrl = "http://localhost:5193/api/todo"

    constructor(private http:HttpClient){}

    getTodos(): Observable<Todo[]>
    {
        return this.http.get<Todo[]>(this.baseUrl);
    }

    addTodo(todo:Todo): Observable<any>
    {
        return this.http.post(this.baseUrl,todo);
    }

    updateTodo(id: string,todo:Todo): Observable<any>
    {
        return this.http.put(`${this.baseUrl}/${id}`,todo);
    }

    deleteTodo(id:string):Observable<any>
    {
        return this.http.delete(`${this.baseUrl}/${id}`);
    }
}