.class public Lcom/google/payment/SkuDetails;
.super Ljava/lang/Object;
.source "SkuDetails.java"


# instance fields
.field private final mCurrencyCode:Ljava/lang/String;

.field private final mDescription:Ljava/lang/String;

.field private final mItemType:Ljava/lang/String;

.field private final mJson:Ljava/lang/String;

.field private final mPrice:Ljava/lang/String;

.field private final mPriceAmountMicros:J

.field private final mPriceCurrencyCode:Ljava/lang/String;

.field private final mSku:Ljava/lang/String;

.field private final mTitle:Ljava/lang/String;

.field private final mType:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;)V
    .locals 1
    .param p1, "jsonSkuDetails"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;
        }
    .end annotation

    .prologue
    .line 38
    const-string v0, "inapp"

    invoke-direct {p0, v0, p1}, Lcom/google/payment/SkuDetails;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 39
    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 4
    .param p1, "itemType"    # Ljava/lang/String;
    .param p2, "jsonSkuDetails"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;
        }
    .end annotation

    .prologue
    .line 41
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 42
    iput-object p1, p0, Lcom/google/payment/SkuDetails;->mItemType:Ljava/lang/String;

    .line 43
    iput-object p2, p0, Lcom/google/payment/SkuDetails;->mJson:Ljava/lang/String;

    .line 44
    new-instance v0, Lorg/json/JSONObject;

    iget-object v1, p0, Lcom/google/payment/SkuDetails;->mJson:Ljava/lang/String;

    invoke-direct {v0, v1}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 45
    .local v0, "o":Lorg/json/JSONObject;
    const-string v1, "productId"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/google/payment/SkuDetails;->mSku:Ljava/lang/String;

    .line 46
    const-string v1, "type"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/google/payment/SkuDetails;->mType:Ljava/lang/String;

    .line 47
    const-string v1, "price"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/google/payment/SkuDetails;->mPrice:Ljava/lang/String;

    .line 48
    const-string v1, "price_amount_micros"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->optLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/google/payment/SkuDetails;->mPriceAmountMicros:J

    .line 49
    const-string v1, "price_currency_code"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/google/payment/SkuDetails;->mPriceCurrencyCode:Ljava/lang/String;

    .line 50
    const-string v1, "title"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/google/payment/SkuDetails;->mTitle:Ljava/lang/String;

    .line 51
    const-string v1, "description"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/google/payment/SkuDetails;->mDescription:Ljava/lang/String;

    .line 53
    const-string v1, "price_currency_code"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/google/payment/SkuDetails;->mCurrencyCode:Ljava/lang/String;

    .line 54
    return-void
.end method


# virtual methods
.method public getDescription()Ljava/lang/String;
    .locals 1

    .prologue
    .line 62
    iget-object v0, p0, Lcom/google/payment/SkuDetails;->mDescription:Ljava/lang/String;

    return-object v0
.end method

.method public getPrice()Ljava/lang/String;
    .locals 1

    .prologue
    .line 58
    iget-object v0, p0, Lcom/google/payment/SkuDetails;->mPrice:Ljava/lang/String;

    return-object v0
.end method

.method public getPriceAmountMicros()J
    .locals 2

    .prologue
    .line 59
    iget-wide v0, p0, Lcom/google/payment/SkuDetails;->mPriceAmountMicros:J

    return-wide v0
.end method

.method public getPriceCurrencyCode()Ljava/lang/String;
    .locals 1

    .prologue
    .line 60
    iget-object v0, p0, Lcom/google/payment/SkuDetails;->mPriceCurrencyCode:Ljava/lang/String;

    return-object v0
.end method

.method public getSku()Ljava/lang/String;
    .locals 1

    .prologue
    .line 56
    iget-object v0, p0, Lcom/google/payment/SkuDetails;->mSku:Ljava/lang/String;

    return-object v0
.end method

.method public getTitle()Ljava/lang/String;
    .locals 1

    .prologue
    .line 61
    iget-object v0, p0, Lcom/google/payment/SkuDetails;->mTitle:Ljava/lang/String;

    return-object v0
.end method

.method public getType()Ljava/lang/String;
    .locals 1

    .prologue
    .line 57
    iget-object v0, p0, Lcom/google/payment/SkuDetails;->mType:Ljava/lang/String;

    return-object v0
.end method

.method public getmCurrencyCode()Ljava/lang/String;
    .locals 1

    .prologue
    .line 66
    iget-object v0, p0, Lcom/google/payment/SkuDetails;->mCurrencyCode:Ljava/lang/String;

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .prologue
    .line 71
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "SkuDetails:"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/google/payment/SkuDetails;->mJson:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
