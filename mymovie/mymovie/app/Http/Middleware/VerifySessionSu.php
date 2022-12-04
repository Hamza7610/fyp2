<?php

namespace App\Http\Middleware;

use Closure;

class VerifySessionSu
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
        $User_activity = $request->session()->get('su_id');
        if ($User_activity == null) {
            return redirect('/su');
        }
        return $next($request);
    }
}
