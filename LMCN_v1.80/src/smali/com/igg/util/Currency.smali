.class public Lcom/igg/util/Currency;
.super Ljava/lang/Object;
.source "Currency.java"


# static fields
.field private static map:Ljava/util/HashMap;
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
    .line 10
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static getCurrency(Ljava/lang/String;)Ljava/lang/String;
    .locals 3
    .param p0, "countryCode"    # Ljava/lang/String;

    .prologue
    .line 23
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    if-nez v0, :cond_0

    .line 24
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    sput-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    .line 25
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "AS"

    const-string v2, "USD"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 27
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "CN"

    const-string v2, "RMB"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 28
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "ES"

    const-string v2, "EUR"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 29
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "TW"

    const-string v2, "TWD"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 30
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "BR"

    const-string v2, "BRL"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 31
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "MX"

    const-string v2, "MXN"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 32
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "TH"

    const-string v2, "THB"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 33
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "RU"

    const-string v2, "RUB"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 34
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "JP"

    const-string v2, "JPY"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 35
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "KR"

    const-string v2, "KRW"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 36
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "ID"

    const-string v2, "IDR"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 37
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "VN"

    const-string v2, "VND"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 38
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "AE"

    const-string v2, "AED"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 39
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "QA"

    const-string v2, "QAR"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 40
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    const-string v1, "EG"

    const-string v2, "EGP"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 43
    :cond_0
    sget-object v0, Lcom/igg/util/Currency;->map:Ljava/util/HashMap;

    invoke-virtual {v0, p0}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    return-object v0
.end method
