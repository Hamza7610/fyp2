<?php

namespace App\Http\Middleware;

use Closure;

class VerifySession
{
    /**
     * Handle an incoming request.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \Closure  $next
     * @return mixed
     */
    public function handle($request, Closure $next)
    {
        $User_activity = $request->session()->get('user_id');
        if ($User_activity == null) {
            return redirect('/');
        }
        return $next($request);
    }
}
