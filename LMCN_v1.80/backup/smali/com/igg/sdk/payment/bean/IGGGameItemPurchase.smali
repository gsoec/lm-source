.class public Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;
.super Ljava/lang/Object;
.source "IGGGameItemPurchase.java"

# interfaces
.implements Ljava/io/Serializable;


# static fields
.field public static final TAG:Ljava/lang/String; = "IGGGameItemPurchase"


# instance fields
.field private USDPrice:D

.field private currency:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

.field private googlePlayCurrencyPrice:Ljava/lang/String;

.field private googlePlayPriceCurrencyCode:Ljava/lang/String;

.field private memo:Ljava/lang/String;

.field private priceRawConfig:Ljava/lang/String;

.field private thirdPartyId:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 18
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static declared-synchronized createFromJSON(Lorg/json/JSONObject;)Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;
    .locals 6
    .param p0, "JSON"    # Lorg/json/JSONObject;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;
        }
    .end annotation

    .prologue
    .line 64
    const-class v2, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    monitor-enter v2

    :try_start_0
    new-instance v0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    invoke-direct {v0}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;-><init>()V

    .line 66
    .local v0, "purchase":Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;
    const-string v1, "pcc_price_cfg"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->priceRawConfig:Ljava/lang/String;

    .line 67
    const-string v1, "pcc_memo"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->memo:Ljava/lang/String;

    .line 68
    const-string v1, "pcc_price_usd"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 69
    const-string v1, "pcc_price_usd"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Double;->parseDouble(Ljava/lang/String;)D

    move-result-wide v4

    iput-wide v4, v0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->USDPrice:D

    .line 75
    :goto_0
    sget-object v1, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->USD:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-static {v1}, Lcom/igg/sdk/payment/bean/IGGCurrency;->detectByCountry(Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;)Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->currency:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 77
    monitor-exit v2

    return-object v0

    .line 71
    :cond_0
    const-wide/16 v4, 0x0

    :try_start_1
    iput-wide v4, v0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->USDPrice:D
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    .line 64
    .end local v0    # "purchase":Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;
    :catchall_0
    move-exception v1

    monitor-exit v2

    throw v1
.end method

.method private lookUpCurrencyPrice(Ljava/lang/String;)[Ljava/lang/String;
    .locals 6
    .param p1, "currency"    # Ljava/lang/String;

    .prologue
    .line 198
    const-string v3, "IGGGameItemPurchase"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "lookUpCurrencyPrice for "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 200
    iget-object v3, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->priceRawConfig:Ljava/lang/String;

    const-string v4, "\\|"

    invoke-virtual {v3, v4}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v0

    .line 202
    .local v0, "components":[Ljava/lang/String;
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_0
    array-length v3, v0

    if-ge v1, v3, :cond_1

    .line 203
    aget-object v3, v0, v1

    const-string v4, ":"

    invoke-virtual {v3, v4}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v2

    .line 204
    .local v2, "parts":[Ljava/lang/String;
    const/4 v3, 0x0

    aget-object v3, v2, v3

    invoke-virtual {v3, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_0

    .line 209
    .end local v2    # "parts":[Ljava/lang/String;
    :goto_1
    return-object v2

    .line 202
    .restart local v2    # "parts":[Ljava/lang/String;
    :cond_0
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 209
    .end local v2    # "parts":[Ljava/lang/String;
    :cond_1
    const/4 v2, 0x0

    goto :goto_1
.end method


# virtual methods
.method public getCurrency()Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;
    .locals 1

    .prologue
    .line 84
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->currency:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    return-object v0
.end method

.method public getCurrencyDisplay()Ljava/lang/String;
    .locals 1

    .prologue
    .line 150
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->currency:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-static {v0}, Lcom/igg/sdk/payment/bean/IGGCurrency;->getDisplayName(Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getFormattedPrice()Ljava/lang/String;
    .locals 4
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 121
    invoke-static {}, Ljava/text/NumberFormat;->getNumberInstance()Ljava/text/NumberFormat;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->currency:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {p0, v1}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->getPriceByCurrency(Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;)D

    move-result-wide v2

    invoke-virtual {v0, v2, v3}, Ljava/text/NumberFormat;->format(D)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public declared-synchronized getGooglePlayCurrencyPrice()Ljava/lang/String;
    .locals 1

    .prologue
    .line 171
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->googlePlayCurrencyPrice:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public getGooglePlayPriceCurrencyCode()Ljava/lang/String;
    .locals 1

    .prologue
    .line 184
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->googlePlayPriceCurrencyCode:Ljava/lang/String;

    return-object v0
.end method

.method public declared-synchronized getMemo()Ljava/lang/String;
    .locals 1

    .prologue
    .line 158
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->memo:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public getPrice()D
    .locals 2
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 109
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->currency:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {p0, v0}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->getPriceByCurrency(Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;)D

    move-result-wide v0

    return-wide v0
.end method

.method public getPriceByCurrency(Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;)D
    .locals 6
    .param p1, "currency"    # Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    const/4 v5, 0x0

    const/4 v4, 0x1

    .line 135
    invoke-virtual {p1}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v1}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->lookUpCurrencyPrice(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v0

    .line 136
    .local v0, "priceInfo":[Ljava/lang/String;
    if-nez v0, :cond_0

    .line 137
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "The price of %s is not found"

    new-array v3, v4, [Ljava/lang/Object;

    invoke-virtual {p1}, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->name()Ljava/lang/String;

    move-result-object v4

    aput-object v4, v3, v5

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 139
    :cond_0
    const-string v1, "currency"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "priceInfo[0]"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    aget-object v3, v0, v5

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 140
    const-string v1, "currency"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "priceInfo[1]"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    aget-object v3, v0, v4

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 141
    aget-object v1, v0, v4

    invoke-static {v1}, Ljava/lang/Double;->parseDouble(Ljava/lang/String;)D

    move-result-wide v2

    return-wide v2
.end method

.method public getPriceRawConfig()Ljava/lang/String;
    .locals 1

    .prologue
    .line 154
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->priceRawConfig:Ljava/lang/String;

    return-object v0
.end method

.method public declared-synchronized getThirdPartyId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 162
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->thirdPartyId:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public getUSDPrice()D
    .locals 2

    .prologue
    .line 100
    iget-wide v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->USDPrice:D

    return-wide v0
.end method

.method public setCurrency(Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;)V
    .locals 0
    .param p1, "currency"    # Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    .prologue
    .line 93
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->currency:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    .line 94
    return-void
.end method

.method public declared-synchronized setGooglePlayCurrencyPrice(Ljava/lang/String;)V
    .locals 1
    .param p1, "googlePlayCurrencyPrice"    # Ljava/lang/String;

    .prologue
    .line 175
    monitor-enter p0

    :try_start_0
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->googlePlayCurrencyPrice:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 176
    monitor-exit p0

    return-void

    .line 175
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public setGooglePlayPriceCurrencyCode(Ljava/lang/String;)V
    .locals 0
    .param p1, "googlePlayPriceCurrencyCode"    # Ljava/lang/String;

    .prologue
    .line 188
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->googlePlayPriceCurrencyCode:Ljava/lang/String;

    .line 189
    return-void
.end method
