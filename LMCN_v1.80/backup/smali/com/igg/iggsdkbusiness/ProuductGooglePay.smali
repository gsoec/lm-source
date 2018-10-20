.class public Lcom/igg/iggsdkbusiness/ProuductGooglePay;
.super Ljava/lang/Object;
.source "ProuductGooglePay.java"


# static fields
.field public static final TAG:Ljava/lang/String; = "ProuductGooglePay"

.field private static instance:Lcom/igg/iggsdkbusiness/ProuductGooglePay;


# instance fields
.field ErrorPaymentFailed:Ljava/lang/String;

.field ErrorPaymentIsNotReady:Ljava/lang/String;

.field IGGID:Ljava/lang/String;

.field PaymentSuccessful:Ljava/lang/String;

.field PurchaseLimitCallBack:Ljava/lang/String;

.field private fisrtinitialize:Z

.field getProductCallBack:Ljava/lang/String;

.field private itemIds:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field payCancelCallBack:Ljava/lang/String;

.field payFailedCallBack:Ljava/lang/String;

.field payGatewayFailedCallBack:Ljava/lang/String;

.field paySuccessCallBack:Ljava/lang/String;

.field protected paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

.field private paymentReady:Z

.field preparingFailedCallBack:Ljava/lang/String;

.field purchaseStartingFailedCallBack:Ljava/lang/String;

.field setFailedCallBack:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 49
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 44
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->fisrtinitialize:Z

    .line 45
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentReady:Z

    .line 61
    const-string v0, "purchaseStartingFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->purchaseStartingFailedCallBack:Ljava/lang/String;

    .line 63
    const-string v0, "setFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->setFailedCallBack:Ljava/lang/String;

    .line 65
    const-string v0, "preparingPaymentFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->preparingFailedCallBack:Ljava/lang/String;

    .line 67
    const-string v0, "paySuccessCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paySuccessCallBack:Ljava/lang/String;

    .line 69
    const-string v0, "payGatewayFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->payGatewayFailedCallBack:Ljava/lang/String;

    .line 71
    const-string v0, "payFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->payFailedCallBack:Ljava/lang/String;

    .line 73
    const-string v0, "getProductCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->getProductCallBack:Ljava/lang/String;

    .line 75
    const-string v0, "payCancelCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->payCancelCallBack:Ljava/lang/String;

    .line 77
    const-string v0, "PurchaseLimitCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->PurchaseLimitCallBack:Ljava/lang/String;

    .line 272
    const-string v0, "1883"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->ErrorPaymentIsNotReady:Ljava/lang/String;

    .line 273
    const-string v0, "1873"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->ErrorPaymentFailed:Ljava/lang/String;

    .line 274
    const-string v0, "1872"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->PaymentSuccessful:Ljava/lang/String;

    .line 51
    return-void
.end method

.method static synthetic access$000(Lcom/igg/iggsdkbusiness/ProuductGooglePay;Ljava/util/List;)Ljava/lang/String;
    .locals 1
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/ProuductGooglePay;
    .param p1, "x1"    # Ljava/util/List;

    .prologue
    .line 41
    invoke-direct {p0, p1}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->getProductTitles(Ljava/util/List;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$102(Lcom/igg/iggsdkbusiness/ProuductGooglePay;Z)Z
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/ProuductGooglePay;
    .param p1, "x1"    # Z

    .prologue
    .line 41
    iput-boolean p1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentReady:Z

    return p1
.end method

.method private getProductTitles(Ljava/util/List;)Ljava/lang/String;
    .locals 11
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;)",
            "Ljava/lang/String;"
        }
    .end annotation

    .prologue
    .line 340
    .local p1, "items":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    iput-object v8, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->itemIds:Ljava/util/ArrayList;

    .line 341
    new-instance v7, Ljava/lang/String;

    invoke-direct {v7}, Ljava/lang/String;-><init>()V

    .line 342
    .local v7, "str":Ljava/lang/String;
    const/4 v2, 0x0

    .local v2, "i":I
    :goto_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v8

    if-ge v2, v8, :cond_2

    .line 343
    invoke-interface {p1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/igg/sdk/payment/bean/IGGGameItem;

    .line 350
    .local v3, "item":Lcom/igg/sdk/payment/bean/IGGGameItem;
    :try_start_0
    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v8

    invoke-virtual {v8}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->getFormattedPrice()Ljava/lang/String;

    move-result-object v6

    .line 351
    .local v6, "price":Ljava/lang/String;
    if-nez v6, :cond_0

    .line 352
    const-string v6, "0"
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 362
    :cond_0
    :goto_1
    :try_start_1
    const-string v1, ""

    .line 364
    .local v1, "googlePrice":Ljava/lang/String;
    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v8

    invoke-virtual {v8}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->getGooglePlayCurrencyPrice()Ljava/lang/String;

    move-result-object v1

    .line 365
    if-nez v1, :cond_1

    .line 366
    const-string v1, ""
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    .line 380
    :cond_1
    :goto_2
    :try_start_2
    const-string v5, ""

    .line 381
    .local v5, "pStartContext":Ljava/lang/String;
    const-string v4, ""

    .line 382
    .local v4, "pEndContext":Ljava/lang/String;
    const-string v5, "{"

    .line 383
    const-string v4, "}"

    .line 384
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v8, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getId()Ljava/lang/Integer;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/Integer;->intValue()I

    move-result v9

    invoke-static {v9}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, ";"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getTitle()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, ";"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, ";"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v9

    invoke-virtual {v9}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->getCurrencyDisplay()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, ";"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    .line 385
    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getFlag()I

    move-result v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, ";"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getFreePoint()Ljava/lang/Integer;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, ";"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPoint()Ljava/lang/Integer;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, ";"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v9

    invoke-virtual {v9}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->getMemo()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, ";"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_2

    move-result-object v7

    .line 391
    .end local v4    # "pEndContext":Ljava/lang/String;
    .end local v5    # "pStartContext":Ljava/lang/String;
    :goto_3
    const-string v8, "ProductTitles"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "getCurrencyDisplay = "

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v10

    invoke-virtual {v10}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->getCurrencyDisplay()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 392
    const-string v8, "ProductTitles"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "getCurrency = "

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v10

    invoke-virtual {v10}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->getCurrency()Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 393
    const-string v8, "ProductTitles"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "getPriceRawConfig = "

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v10

    invoke-virtual {v10}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->getPriceRawConfig()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 342
    add-int/lit8 v2, v2, 0x1

    goto/16 :goto_0

    .line 357
    .end local v1    # "googlePrice":Ljava/lang/String;
    .end local v6    # "price":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 358
    .local v0, "e":Ljava/lang/Exception;
    const-string v6, "0"

    .line 359
    .restart local v6    # "price":Ljava/lang/String;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto/16 :goto_1

    .line 368
    .end local v0    # "e":Ljava/lang/Exception;
    :catch_1
    move-exception v0

    .line 369
    .restart local v0    # "e":Ljava/lang/Exception;
    const-string v1, ""

    .line 370
    .restart local v1    # "googlePrice":Ljava/lang/String;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto/16 :goto_2

    .line 387
    .end local v0    # "e":Ljava/lang/Exception;
    :catch_2
    move-exception v0

    .line 388
    .restart local v0    # "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_3

    .line 395
    .end local v0    # "e":Ljava/lang/Exception;
    .end local v1    # "googlePrice":Ljava/lang/String;
    .end local v3    # "item":Lcom/igg/sdk/payment/bean/IGGGameItem;
    .end local v6    # "price":Ljava/lang/String;
    :cond_2
    return-object v7
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/ProuductGooglePay;
    .locals 1

    .prologue
    .line 54
    sget-object v0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->instance:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    if-nez v0, :cond_0

    .line 55
    new-instance v0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->instance:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    .line 58
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->instance:Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 87
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 88
    return-void
.end method

.method public IsPaymentReady()Z
    .locals 1

    .prologue
    .line 399
    iget-boolean v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentReady:Z

    return v0
.end method

.method getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 96
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method public getProduct()V
    .locals 5

    .prologue
    .line 120
    :try_start_0
    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->IGGID:Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 124
    :goto_0
    const-string v1, "ProuductGooglePay"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "fisrtinitialize = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    iget-boolean v3, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->fisrtinitialize:Z

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 125
    iget-boolean v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->fisrtinitialize:Z

    if-nez v1, :cond_1

    .line 127
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    if-eqz v1, :cond_0

    .line 129
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    const-string v2, "android"

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v3}, Lcom/igg/sdk/payment/google/IGGPayment;->isAvailable()Z

    move-result v3

    new-instance v4, Lcom/igg/iggsdkbusiness/ProuductGooglePay$1;

    invoke-direct {v4, p0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay$1;-><init>(Lcom/igg/iggsdkbusiness/ProuductGooglePay;)V

    invoke-virtual {v1, v2, v3, v4}, Lcom/igg/sdk/payment/google/IGGPayment;->loadItems(Ljava/lang/String;ZLcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;)Z

    .line 271
    :cond_0
    :goto_1
    return-void

    .line 121
    :catch_0
    move-exception v0

    .line 122
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0

    .line 161
    .end local v0    # "e":Ljava/lang/Exception;
    :cond_1
    new-instance v1, Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->getActivity()Landroid/app/Activity;

    move-result-object v2

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->IGGID:Ljava/lang/String;

    invoke-direct {v1, v2, v3, v4}, Lcom/igg/sdk/payment/google/IGGPayment;-><init>(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;)V

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    .line 164
    :try_start_1
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    new-instance v2, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay$2;-><init>(Lcom/igg/iggsdkbusiness/ProuductGooglePay;)V

    invoke-virtual {v1, v2}, Lcom/igg/sdk/payment/google/IGGPayment;->initialize(Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;)V

    .line 266
    const/4 v1, 0x0

    iput-boolean v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->fisrtinitialize:Z
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    goto :goto_1

    .line 267
    :catch_1
    move-exception v0

    .line 268
    .restart local v0    # "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_1
.end method

.method public getProduct(Ljava/lang/String;)V
    .locals 2
    .param p1, "iggid"    # Ljava/lang/String;

    .prologue
    .line 105
    if-eqz p1, :cond_0

    const-string v0, ""

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 106
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->setFailedCallBack:Ljava/lang/String;

    const-string v1, "iggid\u4e0d\u80fd\u4e3a\u7a7a"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 112
    :goto_0
    return-void

    .line 110
    :cond_1
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->IGGID:Ljava/lang/String;

    .line 111
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->getProduct()V

    goto :goto_0
.end method

.method public handleResult(IILandroid/content/Intent;)V
    .locals 2
    .param p1, "requestCode"    # I
    .param p2, "resultCode"    # I
    .param p3, "data"    # Landroid/content/Intent;

    .prologue
    .line 430
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    if-eqz v0, :cond_0

    .line 432
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v0}, Lcom/igg/sdk/payment/google/IGGPayment;->getIABHelper()Lcom/google/payment/IabHelper;

    move-result-object v0

    if-nez v0, :cond_1

    .line 445
    :cond_0
    :goto_0
    return-void

    .line 434
    :cond_1
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v0}, Lcom/igg/sdk/payment/google/IGGPayment;->isAvailable()Z

    move-result v0

    if-eqz v0, :cond_2

    .line 435
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v0}, Lcom/igg/sdk/payment/google/IGGPayment;->getIABHelper()Lcom/google/payment/IabHelper;

    move-result-object v0

    invoke-virtual {v0, p1, p2, p3}, Lcom/google/payment/IabHelper;->handleActivityResult(IILandroid/content/Intent;)Z

    move-result v0

    if-nez v0, :cond_0

    goto :goto_0

    .line 442
    :cond_2
    const-string v0, "onActivityResult"

    const-string v1, "onActivityResult"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public onDestroy()V
    .locals 2

    .prologue
    .line 449
    :try_start_0
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    if-eqz v1, :cond_0

    .line 450
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v1}, Lcom/igg/sdk/payment/google/IGGPayment;->finalize()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 454
    :cond_0
    :goto_0
    return-void

    .line 451
    :catch_0
    move-exception v0

    .line 452
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method public pay(Ljava/lang/String;)V
    .locals 4
    .param p1, "prudctID"    # Ljava/lang/String;

    .prologue
    .line 283
    :try_start_0
    const-string v1, "ProuductGooglePay"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "getPurchaseLimit = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v3}, Lcom/igg/sdk/payment/google/IGGPayment;->getPurchaseLimit()I

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 284
    iget-boolean v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentReady:Z

    if-nez v1, :cond_1

    .line 287
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->preparingFailedCallBack:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->ErrorPaymentIsNotReady:Ljava/lang/String;

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 288
    const-string v1, "ProuductGooglePay"

    const-string v2, "!paymentReady"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 332
    :cond_0
    :goto_0
    return-void

    .line 292
    :cond_1
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v1}, Lcom/igg/sdk/payment/google/IGGPayment;->getPurchaseLimit()I

    move-result v1

    const/4 v2, 0x3

    if-ne v1, v2, :cond_2

    .line 293
    const-string v1, "ProuductGooglePay"

    const-string v2, "\u8d26\u53f7\u548c\u8bbe\u5907\u90fd\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 294
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v2, "3"

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 314
    :catch_0
    move-exception v0

    .line 315
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0

    .line 298
    .end local v0    # "e":Ljava/lang/Exception;
    :cond_2
    :try_start_1
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v1}, Lcom/igg/sdk/payment/google/IGGPayment;->getPurchaseLimit()I

    move-result v1

    const/4 v2, 0x2

    if-ne v1, v2, :cond_3

    .line 299
    const-string v1, "ProuductGooglePay"

    const-string v2, "\u8bbe\u5907\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 300
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v2, "1"

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 304
    :cond_3
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v1}, Lcom/igg/sdk/payment/google/IGGPayment;->getPurchaseLimit()I

    move-result v1

    const/4 v2, 0x1

    if-ne v1, v2, :cond_4

    .line 305
    const-string v1, "ProuductGooglePay"

    const-string v2, "\u8d26\u53f7\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 306
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v2, "2"

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 310
    :cond_4
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v1}, Lcom/igg/sdk/payment/google/IGGPayment;->getPurchaseLimit()I

    move-result v1

    if-nez v1, :cond_0

    .line 311
    const-string v1, "ProuductGooglePay"

    const-string v2, "IGGPaymentPurchaseLimitationUser"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 312
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->paymentManager:Lcom/igg/sdk/payment/google/IGGPayment;

    invoke-virtual {v1, p1}, Lcom/igg/sdk/payment/google/IGGPayment;->pay(Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method

.method public payCancelCallBack()V
    .locals 2

    .prologue
    .line 81
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->payCancelCallBack:Ljava/lang/String;

    const-string v1, "The Item you were attempting to purchase could not be found."

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 82
    return-void
.end method
