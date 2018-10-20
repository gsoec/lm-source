.class public Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;
.super Ljava/lang/Object;
.source "IGGPaymentCardsLoader.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;,
        Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;
    }
.end annotation


# static fields
.field private static final BUSINESS_ERROR_CODE_THRESHOLD:I = 0x64

.field private static final TAG:Ljava/lang/String; = "PaymentCardsLoader"


# instance fields
.field private IGGId:Ljava/lang/String;

.field private channelName:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "IGGId"    # Ljava/lang/String;
    .param p2, "channelName"    # Ljava/lang/String;

    .prologue
    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 31
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->IGGId:Ljava/lang/String;

    .line 32
    iput-object p2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->channelName:Ljava/lang/String;

    .line 33
    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;Lorg/json/JSONObject;)I
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;
    .param p1, "x1"    # Lorg/json/JSONObject;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;
        }
    .end annotation

    .prologue
    .line 23
    invoke-direct {p0, p1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->parseLimitation(Lorg/json/JSONObject;)I

    move-result v0

    return v0
.end method

.method static synthetic access$100(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;Lorg/json/JSONObject;)Ljava/util/ArrayList;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;
    .param p1, "x1"    # Lorg/json/JSONObject;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;
        }
    .end annotation

    .prologue
    .line 23
    invoke-direct {p0, p1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->parseCards(Lorg/json/JSONObject;)Ljava/util/ArrayList;

    move-result-object v0

    return-object v0
.end method

.method private parseCards(Lorg/json/JSONObject;)Ljava/util/ArrayList;
    .locals 5
    .param p1, "cardData"    # Lorg/json/JSONObject;
    .annotation build Landroid/support/annotation/NonNull;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lorg/json/JSONObject;",
            ")",
            "Ljava/util/ArrayList",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;
        }
    .end annotation

    .prologue
    .line 75
    const-string v4, "card_data"

    invoke-virtual {p1, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 76
    .local v0, "cards":Ljava/lang/String;
    new-instance v1, Lorg/json/JSONArray;

    invoke-direct {v1, v0}, Lorg/json/JSONArray;-><init>(Ljava/lang/String;)V

    .line 77
    .local v1, "cardsJsonArray":Lorg/json/JSONArray;
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    .line 78
    .local v2, "gameItems":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    const/4 v3, 0x0

    .local v3, "i":I
    :goto_0
    invoke-virtual {v1}, Lorg/json/JSONArray;->length()I

    move-result v4

    if-ge v3, v4, :cond_0

    .line 79
    invoke-virtual {v1, v3}, Lorg/json/JSONArray;->getJSONObject(I)Lorg/json/JSONObject;

    move-result-object v4

    invoke-static {v4}, Lcom/igg/sdk/payment/bean/IGGGameItem;->createFromJSON(Lorg/json/JSONObject;)Lcom/igg/sdk/payment/bean/IGGGameItem;

    move-result-object v4

    invoke-virtual {v2, v4}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 78
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 81
    :cond_0
    return-object v2
.end method

.method private parseLimitation(Lorg/json/JSONObject;)I
    .locals 6
    .param p1, "limitData"    # Lorg/json/JSONObject;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;
        }
    .end annotation

    .prologue
    .line 85
    const-string v3, "user_limit"

    invoke-virtual {p1, v3}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v2

    .line 86
    .local v2, "userLimit":Z
    const/4 v1, 0x0

    .line 87
    .local v1, "purchaseLimit":I
    if-eqz v2, :cond_0

    .line 88
    or-int/lit8 v1, v1, 0x1

    .line 90
    :cond_0
    const-string v3, "PaymentCardsLoader"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "user_limit=>"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 92
    const-string v3, "device_limit"

    invoke-virtual {p1, v3}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v0

    .line 93
    .local v0, "deviceLimit":Z
    if-eqz v0, :cond_1

    .line 94
    or-int/lit8 v1, v1, 0x2

    .line 96
    :cond_1
    const-string v3, "PaymentCardsLoader"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "ifDeviceLimit=>"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 97
    return v1
.end method


# virtual methods
.method public loadItems(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;)V
    .locals 4
    .param p1, "listener"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;

    .prologue
    .line 36
    new-instance v0, Lcom/igg/sdk/service/IGGPaymentService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGPaymentService;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->IGGId:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->channelName:Ljava/lang/String;

    new-instance v3, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;

    invoke-direct {v3, p0, p1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;-><init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;)V

    invoke-virtual {v0, v1, v2, v3}, Lcom/igg/sdk/service/IGGPaymentService;->loadItems(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;)V

    .line 71
    return-void
.end method
