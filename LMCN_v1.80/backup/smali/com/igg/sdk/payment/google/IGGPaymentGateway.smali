.class public Lcom/igg/sdk/payment/google/IGGPaymentGateway;
.super Lcom/igg/sdk/service/IGGService;
.source "IGGPaymentGateway.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalPurchaseFinishedListener;,
        Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;,
        Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;
    }
.end annotation


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGPaymentGateway"


# instance fields
.field private requestTimes:I

.field private startTime:J


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 29
    invoke-direct {p0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)I
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    .prologue
    .line 29
    iget v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->requestTimes:I

    return v0
.end method

.method static synthetic access$008(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)I
    .locals 2
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    .prologue
    .line 29
    iget v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->requestTimes:I

    add-int/lit8 v1, v0, 0x1

    iput v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->requestTimes:I

    return v0
.end method

.method static synthetic access$100(Lcom/igg/sdk/payment/google/IGGPaymentGateway;Ljava/lang/String;Ljava/util/Map;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway;
    .param p1, "x1"    # Ljava/lang/String;
    .param p2, "x2"    # Ljava/util/Map;

    .prologue
    .line 29
    invoke-direct {p0, p1, p2}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->sendPayReport(Ljava/lang/String;Ljava/util/Map;)V

    return-void
.end method

.method static synthetic access$202(Lcom/igg/sdk/payment/google/IGGPaymentGateway;J)J
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway;
    .param p1, "x1"    # J

    .prologue
    .line 29
    iput-wide p1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->startTime:J

    return-wide p1
.end method

.method private sendPayReport(Ljava/lang/String;Ljava/util/Map;)V
    .locals 6
    .param p1, "url"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;>;)V"
        }
    .end annotation

    .prologue
    .line 368
    .local p2, "headerFieldsMap":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/util/List<Ljava/lang/String;>;>;"
    :try_start_0
    const-string v4, "X-IGG-DIRECTIVES"

    invoke-interface {p2, v4}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/util/List;

    .line 369
    .local v2, "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    if-eqz v2, :cond_0

    .line 370
    const/4 v4, 0x0

    invoke-interface {v2, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 371
    .local v3, "value":Ljava/lang/String;
    if-eqz v3, :cond_1

    .line 372
    new-instance v4, Lorg/json/JSONObject;

    invoke-direct {v4, v3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    const-string v5, "report_profile"

    invoke-virtual {v4, v5}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v1

    .line 373
    .local v1, "flag":Z
    if-eqz v1, :cond_0

    .line 374
    invoke-direct {p0, p1}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->sendReport(Ljava/lang/String;)V

    .line 392
    .end local v1    # "flag":Z
    .end local v2    # "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    .end local v3    # "value":Ljava/lang/String;
    :cond_0
    :goto_0
    return-void

    .line 377
    .restart local v2    # "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    .restart local v3    # "value":Ljava/lang/String;
    :cond_1
    const-string v4, "IGGPaymentGateway"

    const-string v5, "X-IGG-DIRECTIVES value is null"

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 389
    .end local v2    # "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    .end local v3    # "value":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 390
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method private sendReport(Ljava/lang/String;)V
    .locals 14
    .param p1, "url"    # Ljava/lang/String;

    .prologue
    .line 395
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    .line 396
    .local v2, "endTime":J
    iget-wide v8, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->startTime:J

    sub-long v6, v2, v8

    .line 397
    .local v6, "lengthTime":J
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-static {p1}, Lcom/igg/util/UtilTool;->getDns(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "/api/report.php?id=profile"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    .line 398
    .local v5, "reportUrl":Ljava/lang/String;
    const-string v8, "IGGPaymentGateway"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "reportUrl:"

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 400
    :try_start_0
    new-instance v4, Lorg/json/JSONObject;

    invoke-direct {v4}, Lorg/json/JSONObject;-><init>()V

    .line 401
    .local v4, "jsonData":Lorg/json/JSONObject;
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1}, Lorg/json/JSONObject;-><init>()V

    .line 402
    .local v1, "json":Lorg/json/JSONObject;
    const-string v8, "seconds_cost"

    long-to-double v10, v6

    const-wide v12, 0x408f400000000000L    # 1000.0

    div-double/2addr v10, v12

    invoke-static {v10, v11}, Ljava/lang/String;->valueOf(D)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v1, v8, v9}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 403
    const-string v8, "transaction_completion"

    invoke-virtual {v4, v8, v1}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 404
    const-string v8, "IGGPaymentGateway"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "jsonData:"

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v4}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 405
    new-instance v8, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v8}, Lcom/igg/sdk/service/IGGService;-><init>()V

    invoke-virtual {v4}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v9

    new-instance v10, Lcom/igg/sdk/payment/google/IGGPaymentGateway$4;

    invoke-direct {v10, p0}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$4;-><init>(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)V

    invoke-virtual {v8, v5, v9, v10}, Lcom/igg/sdk/service/IGGService;->postJSONRequest(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    .line 438
    .end local v1    # "json":Lorg/json/JSONObject;
    .end local v4    # "jsonData":Lorg/json/JSONObject;
    :goto_0
    return-void

    .line 435
    :catch_0
    move-exception v0

    .line 436
    .local v0, "e":Lorg/json/JSONException;
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    goto :goto_0
.end method


# virtual methods
.method public postPayAmazon(Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;)V
    .locals 8
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "actualAPI"    # Ljava/lang/String;
    .param p4, "listener"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 216
    .local p3, "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const/16 v6, 0x3a98

    new-instance v7, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v0

    invoke-direct {v7, v0}, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;-><init>(Landroid/content/Context;)V

    new-instance v0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;

    move-object v1, p0

    move-object v2, p2

    move-object v3, p1

    move-object v4, p3

    move-object v5, p4

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;-><init>(Lcom/igg/sdk/payment/google/IGGPaymentGateway;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;)V

    move-object v1, p0

    move-object v2, p2

    move-object v3, p3

    move v4, v6

    move-object v5, v7

    move-object v6, v0

    invoke-super/range {v1 .. v6}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$HeadersRequestListener;)V

    .line 262
    return-void
.end method

.method public postPayGooglePlay(Lcom/igg/sdk/IGGSDKConstant$PaymentType;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/google/payment/Purchase;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;)V
    .locals 10
    .param p1, "type"    # Lcom/igg/sdk/IGGSDKConstant$PaymentType;
    .param p2, "gameId"    # Ljava/lang/String;
    .param p3, "actualAPI"    # Ljava/lang/String;
    .param p5, "purchase"    # Lcom/google/payment/Purchase;
    .param p6, "listener"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/IGGSDKConstant$PaymentType;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/google/payment/Purchase;",
            "Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 112
    .local p4, "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const/16 v8, 0x3a98

    new-instance v9, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v0

    invoke-direct {v9, v0}, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;-><init>(Landroid/content/Context;)V

    new-instance v0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;

    move-object v1, p0

    move-object v2, p3

    move-object v3, p1

    move-object v4, p2

    move-object v5, p4

    move-object v6, p5

    move-object/from16 v7, p6

    invoke-direct/range {v0 .. v7}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;-><init>(Lcom/igg/sdk/payment/google/IGGPaymentGateway;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$PaymentType;Ljava/lang/String;Ljava/util/HashMap;Lcom/google/payment/Purchase;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;)V

    move-object v1, p0

    move-object v2, p3

    move-object v3, p4

    move v4, v8

    move-object v5, v9

    move-object v6, v0

    invoke-super/range {v1 .. v6}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$HeadersRequestListener;)V

    .line 178
    return-void
.end method

.method public postPayTstore(Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalPurchaseFinishedListener;)V
    .locals 8
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "actualAPI"    # Ljava/lang/String;
    .param p4, "listener"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalPurchaseFinishedListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalPurchaseFinishedListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 313
    .local p3, "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const/16 v6, 0x3a98

    new-instance v7, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v0

    invoke-direct {v7, v0}, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;-><init>(Landroid/content/Context;)V

    new-instance v0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$3;

    move-object v1, p0

    move-object v2, p2

    move-object v3, p1

    move-object v4, p3

    move-object v5, p4

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$3;-><init>(Lcom/igg/sdk/payment/google/IGGPaymentGateway;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalPurchaseFinishedListener;)V

    move-object v1, p0

    move-object v2, p2

    move-object v3, p3

    move v4, v6

    move-object v5, v7

    move-object v6, v0

    invoke-super/range {v1 .. v6}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$HeadersRequestListener;)V

    .line 356
    return-void
.end method

.method public submit(Lcom/igg/sdk/IGGSDKConstant$PaymentType;Lcom/google/payment/Purchase;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;)V
    .locals 9
    .param p1, "type"    # Lcom/igg/sdk/IGGSDKConstant$PaymentType;
    .param p2, "purchase"    # Lcom/google/payment/Purchase;
    .param p3, "gameId"    # Ljava/lang/String;
    .param p4, "IGGId"    # Ljava/lang/String;
    .param p5, "listener"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;

    .prologue
    .line 85
    const/4 v0, 0x0

    iput v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->requestTimes:I

    .line 86
    invoke-virtual {p2}, Lcom/google/payment/Purchase;->getSignature()Ljava/lang/String;

    move-result-object v7

    .line 87
    .local v7, "signature":Ljava/lang/String;
    invoke-virtual {p2}, Lcom/google/payment/Purchase;->getOriginalJson()Ljava/lang/String;

    move-result-object v8

    .line 89
    .local v8, "signedData":Ljava/lang/String;
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->BAZAAR:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    if-ne p1, v0, :cond_0

    .line 90
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_SKYUNION:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v2, "cafebazaar/callback.php"

    invoke-static {v1, v2}, Lcom/igg/sdk/IGGURLHelper;->getPayGatewayAPI(Lcom/igg/sdk/IGGSDKConstant$PayDNS;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "?gameid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .line 95
    .local v3, "actualAPI":Ljava/lang/String;
    :goto_0
    new-instance v4, Ljava/util/HashMap;

    invoke-direct {v4}, Ljava/util/HashMap;-><init>()V

    .line 96
    .local v4, "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v0, "IGGPaymentGateway"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "signed_data: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 97
    const-string v0, "IGGPaymentGateway"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "signature: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 98
    const-string v0, "IGGPaymentGateway"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "u_id: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 99
    const-string v0, "IGGPaymentGateway"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "orderId: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p2}, Lcom/google/payment/Purchase;->getOrderId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 100
    const-string v0, "IGGPaymentGateway"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "mSku: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p2}, Lcom/google/payment/Purchase;->getSku()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 101
    const-string v0, "IGGPaymentGateway"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "mDeveloperPayload: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p2}, Lcom/google/payment/Purchase;->getDeveloperPayload()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 102
    const-string v0, "signed_data"

    invoke-virtual {v4, v0, v8}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 103
    const-string v0, "signature"

    invoke-virtual {v4, v0, v7}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 104
    const-string v0, "u_id"

    invoke-static {p4}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Integer;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v4, v0, v1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 105
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iput-wide v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->startTime:J

    move-object v0, p0

    move-object v1, p1

    move-object v2, p3

    move-object v5, p2

    move-object v6, p5

    .line 106
    invoke-virtual/range {v0 .. v6}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->postPayGooglePlay(Lcom/igg/sdk/IGGSDKConstant$PaymentType;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/google/payment/Purchase;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;)V

    .line 107
    return-void

    .line 92
    .end local v3    # "actualAPI":Ljava/lang/String;
    .end local v4    # "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    :cond_0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_SKYUNION:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v2, "android/callback.php"

    invoke-static {v1, v2}, Lcom/igg/sdk/IGGURLHelper;->getPayGatewayAPI(Lcom/igg/sdk/IGGSDKConstant$PayDNS;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "?gameid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .restart local v3    # "actualAPI":Ljava/lang/String;
    goto/16 :goto_0
.end method

.method public submit(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;)V
    .locals 6
    .param p1, "receiptId"    # Ljava/lang/String;
    .param p2, "amazonUserID"    # Ljava/lang/String;
    .param p3, "gameId"    # Ljava/lang/String;
    .param p4, "iggId"    # Ljava/lang/String;
    .param p5, "sku"    # Ljava/lang/String;
    .param p6, "serverId"    # Ljava/lang/String;
    .param p7, "listener"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;

    .prologue
    .line 191
    const/4 v3, 0x0

    iput v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->requestTimes:I

    .line 192
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v4, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_SKYUNION:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v5, "amazon_mobile/callback.php"

    invoke-static {v4, v5}, Lcom/igg/sdk/IGGURLHelper;->getPayGatewayAPI(Lcom/igg/sdk/IGGSDKConstant$PayDNS;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "?gameid="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 194
    .local v1, "actualAPI":Ljava/lang/String;
    move-object v0, p4

    .line 196
    .local v0, "IGGId":Ljava/lang/String;
    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    .line 197
    .local v2, "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v3, "purchase_token"

    invoke-virtual {v2, v3, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 198
    const-string v3, "receipt_id"

    invoke-virtual {v2, v3, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 199
    const-string v3, "amazon_user_id"

    invoke-virtual {v2, v3, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 200
    const-string v3, "v"

    const-string v4, "2"

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 201
    if-eqz p6, :cond_0

    .line 202
    const-string v3, "server_id"

    invoke-virtual {v2, v3, p6}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 205
    :cond_0
    if-eqz p5, :cond_1

    .line 206
    const-string v3, "sku"

    invoke-virtual {v2, v3, p5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 207
    const-string v3, "product_id"

    invoke-virtual {v2, v3, p5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 210
    :cond_1
    const-string v3, "u_id"

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Integer;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 211
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    iput-wide v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->startTime:J

    .line 212
    invoke-virtual {p0, p3, v1, v2, p7}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->postPayAmazon(Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;)V

    .line 213
    return-void
.end method

.method public submit(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalPurchaseFinishedListener;)V
    .locals 5
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "txId"    # Ljava/lang/String;
    .param p3, "receiptId"    # Ljava/lang/String;
    .param p4, "iggId"    # Ljava/lang/String;
    .param p5, "client_ver"    # Ljava/lang/String;
    .param p6, "device_id"    # Ljava/lang/String;
    .param p7, "server_id"    # Ljava/lang/String;
    .param p8, "listener"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalPurchaseFinishedListener;

    .prologue
    .line 277
    const/4 v2, 0x0

    iput v2, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->requestTimes:I

    .line 278
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v3, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_SKYUNION:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v4, "tstore/callback.php"

    invoke-static {v3, v4}, Lcom/igg/sdk/IGGURLHelper;->getPayGatewayAPI(Lcom/igg/sdk/IGGSDKConstant$PayDNS;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "?gameid="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 279
    .local v1, "url":Ljava/lang/String;
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 280
    .local v0, "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "txid"

    invoke-virtual {v0, v2, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 282
    const-string v2, "signdata"

    invoke-virtual {v0, v2, p3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 283
    const-string v2, "u_id"

    invoke-virtual {v0, v2, p4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 285
    const-string v2, "IGGPaymentGateway"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "iggId:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 286
    const-string v2, "IGGPaymentGateway"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "txId:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 287
    const-string v2, "IGGPaymentGateway"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "gameid:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 288
    const-string v2, "IGGPaymentGateway"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "receiptId:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-static {p3}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 290
    if-nez p5, :cond_0

    .line 291
    const-string v2, "client_ver"

    const-string v3, ""

    invoke-virtual {v0, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 296
    :goto_0
    if-nez p6, :cond_1

    .line 297
    const-string v2, "device_id"

    const-string v3, ""

    invoke-virtual {v0, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 302
    :goto_1
    if-nez p7, :cond_2

    .line 303
    const-string v2, "server_id"

    const-string v3, ""

    invoke-virtual {v0, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 308
    :goto_2
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->startTime:J

    .line 309
    invoke-virtual {p0, p1, v1, v0, p8}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->postPayTstore(Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalPurchaseFinishedListener;)V

    .line 310
    return-void

    .line 293
    :cond_0
    const-string v2, "client_ver"

    invoke-virtual {v0, v2, p5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    .line 299
    :cond_1
    const-string v2, "device_id"

    invoke-virtual {v0, v2, p6}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_1

    .line 305
    :cond_2
    const-string v2, "server_id"

    invoke-virtual {v0, v2, p7}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_2
.end method
