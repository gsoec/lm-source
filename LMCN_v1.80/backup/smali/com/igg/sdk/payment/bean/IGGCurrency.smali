.class public Lcom/igg/sdk/payment/bean/IGGCurrency;
.super Ljava/lang/Object;
.source "IGGCurrency.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;
    }
.end annotation


# static fields
.field private static countryCurrencyMap:Ljava/util/HashMap;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private static displayNameMap:Ljava/util/HashMap;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 14
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static detectByCountry(Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;)Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;
    .locals 5
    .param p0, "defaultValue"    # Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    .prologue
    .line 39
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    if-nez v2, :cond_0

    .line 40
    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    sput-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    .line 41
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "AS"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->USD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 42
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "TW"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->TWD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 43
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "BR"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->BRL:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 44
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "MX"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->MXN:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 45
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "TH"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->THB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 46
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "RU"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->RUB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 47
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "JP"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->JPY:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 48
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "KR"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->KRW:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 49
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "VN"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->VND:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 50
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "ID"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->IDR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 51
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "CN"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->RMB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 52
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "DE"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->EUR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 53
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "ES"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->EUR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 54
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "IT"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->EUR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 55
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "PT"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->EUR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 56
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "FR"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->EUR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 57
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "TR"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->TRY:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 58
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "SA"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->SAR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 59
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "AE"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->AED:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 60
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "QA"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->QAR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 61
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "EG"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->EGP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 62
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "IN"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->INR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 64
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "CA"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->CAD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 65
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "GB"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->GBP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 66
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "AU"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->AUD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 68
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "PH"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->PHP:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 70
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    const-string v3, "MY"

    sget-object v4, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->MYR:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v4}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 73
    :cond_0
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    invoke-static {v2}, Lcom/igg/util/DeviceUtil;->getCountryCode(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v2

    sget-object v3, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-virtual {v2, v3}, Ljava/lang/String;->toUpperCase(Ljava/util/Locale;)Ljava/lang/String;

    move-result-object v0

    .line 75
    .local v0, "countryCode":Ljava/lang/String;
    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency;->countryCurrencyMap:Ljava/util/HashMap;

    invoke-virtual {v2, v0}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 76
    .local v1, "currencyName":Ljava/lang/String;
    if-nez v1, :cond_1

    .line 80
    .end local p0    # "defaultValue":Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;
    :goto_0
    return-object p0

    .restart local p0    # "defaultValue":Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;
    :cond_1
    invoke-static {v1}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->valueOf(Ljava/lang/String;)Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    move-result-object p0

    goto :goto_0
.end method

.method public static getDisplayName(Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;)Ljava/lang/String;
    .locals 4
    .param p0, "currency"    # Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    .prologue
    .line 89
    sget-object v1, Lcom/igg/sdk/payment/bean/IGGCurrency;->displayNameMap:Ljava/util/HashMap;

    if-nez v1, :cond_0

    .line 90
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    sput-object v1, Lcom/igg/sdk/payment/bean/IGGCurrency;->displayNameMap:Ljava/util/HashMap;

    .line 91
    sget-object v1, Lcom/igg/sdk/payment/bean/IGGCurrency;->displayNameMap:Ljava/util/HashMap;

    sget-object v2, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->TWD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v2}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v2

    const-string v3, "NT$"

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 94
    :cond_0
    sget-object v1, Lcom/igg/sdk/payment/bean/IGGCurrency;->displayNameMap:Ljava/util/HashMap;

    invoke-virtual {p0}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 95
    .local v0, "display":Ljava/lang/String;
    if-nez v0, :cond_1

    .line 96
    invoke-virtual {p0}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v0

    .line 99
    .end local v0    # "display":Ljava/lang/String;
    :cond_1
    return-object v0
.end method
