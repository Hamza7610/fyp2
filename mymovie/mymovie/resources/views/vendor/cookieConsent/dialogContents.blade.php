<div class="js-cookie-consent cookie-consent alert info w3-margin">
    <div class="w3-row">
        <span class="cookie-consent__message">
            {!! trans('cookieConsent::texts.message') !!}
        </span>
    </div>

    <div class="w3-row">
        <button class="js-cookie-consent-agree cookie-consent__agree w3-button w3-black">
            {{ trans('cookieConsent::texts.agree') }}
        </button>
    </div>


</div>
<style>
    .info {
        border-color: white;
        background-color: #1a191f;
        bottom: 0;
        position: fixed;
        color: yellow;
    }
</style>