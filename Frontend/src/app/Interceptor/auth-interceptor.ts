import { serverRoutes } from './../app.routes.server';
import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject, Inject } from '@angular/core';
import { catchError, switchMap, throwError } from 'rxjs';
import { AuthServices } from '../Services/auth-services';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  var authService =  inject(AuthServices);
  var token = localStorage.getItem('token');

  let authReq=req;
  if (token) {
  authReq = req.clone({
    setHeaders:{
      'Authorization': `Bearer ${token}`
    }
  })
  }
  
return next(authReq).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status == 401) {
        // ✅ RETURN the refresh token observable, don't just subscribe to it
        return authService.getRefreshToken().pipe(
          switchMap(res => {
            console.log(res);
            localStorage.setItem('token', res.token);
            
            // ✅ Retry the original request with the new token
            const retryReq = req.clone({
              setHeaders: {
                'Authorization': `Bearer ${res.token}`
              }
            });
            
            return next(retryReq);
          }),
        );
      }
      return throwError(() => error);
    })
  );
};