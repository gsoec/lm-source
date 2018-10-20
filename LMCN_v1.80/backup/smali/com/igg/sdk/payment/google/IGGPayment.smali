.class public Lcom/igg/sdk/payment/google/IGGPayment;
.super Ljava/lang/Object;
.source "IGGPayment.java"

# interfaces
.implements Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;
.implements Lcom/google/payment/IabHelper$OnConsumeFinishedListener;
.implements Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;
.implements Lcom/google/payment/IabHelper$OnIabSetupFinishedListener;
.implements Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;
.implements Lcom/google/payment/IabBroadcastReceiver$IabBroadcastListener;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;,
        Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;,
        Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;
    }
.end annotation


# static fields
.field public static final FRAUD_REPAY_ORDER_TYPE:Ljava/lang/String; = "5"

.field public static final NORMAL_ORDER_TYPE:Ljava/lang/String; = "1"

.field public static final PURCHASE_QUEST_CODE:I = 0xd1d2

.field static final TAG:Ljava/lang/String; = "IGGPayment"


# instance fields
.field private activity:Landroid/app/Activity;

.field private gameId:Ljava/lang/String;

.field private helper:Lcom/google/payment/IabHelper;

.field private iggId:Ljava/lang/String;

.field private isAvailable:Z

.field private isLocked:Z

.field mBroadcastReceiver:Lcom/google/payment/IabBroadcastReceiver;

.field private manager:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

.field private ownedPurchase:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/google/payment/Purchase;",
            ">;"
        }
    .end annotation
.end field

.field private payType:Lcom/igg/sdk/IGGSDKConstant$orderType;

.field paymentType:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

.field private prevIGGId:Ljava/lang/String;

.field private purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

.field private rmId:Ljava/lang/String;


# direct methods
.method public constructor <init>(Landroid/app/Activity;Lcom/igg/sdk/IGGSDKConstant$PaymentType;Ljava/lang/String;Ljava/lang/String;)V
    .locals 2
    .param p1, "context"    # Landroid/app/Activity;
    .param p2, "paymentType"    # Lcom/igg/sdk/IGGSDKConstant$PaymentType;
    .param p3, "gameId"    # Ljava/lang/String;
    .param p4, "iggId"    # Ljava/lang/String;

    .prologue
    const/4 v1, 0x0

    const/4 v0, 0x0

    .line 167
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 50
    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    .line 51
    iput-boolean v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isAvailable:Z

    .line 54
    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->ownedPurchase:Ljava/util/List;

    .line 56
    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->activity:Landroid/app/Activity;

    .line 59
    iput-boolean v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 73
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->prevIGGId:Ljava/lang/String;

    .line 168
    iput-object p3, p0, Lcom/igg/sdk/payment/google/IGGPayment;->gameId:Ljava/lang/String;

    .line 169
    iput-object p4, p0, Lcom/igg/sdk/payment/google/IGGPayment;->iggId:Ljava/lang/String;

    .line 170
    iput-object p2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->paymentType:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    .line 171
    iput-object p1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->activity:Landroid/app/Activity;

    .line 172
    return-void
.end method

.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "context"    # Landroid/app/Activity;
    .param p2, "gameId"    # Ljava/lang/String;
    .param p3, "iggId"    # Ljava/lang/String;

    .prologue
    .line 187
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    invoke-direct {p0, p1, v0, p2, p3}, Lcom/igg/sdk/payment/google/IGGPayment;-><init>(Landroid/app/Activity;Lcom/igg/sdk/IGGSDKConstant$PaymentType;Ljava/lang/String;Ljava/lang/String;)V

    .line 188
    return-void
.end method

.method private startPay(Ljava/lang/String;)V
    .locals 14
    .param p1, "prudctID"    # Ljava/lang/String;

    .prologue
    .line 345
    const-string v0, "IGGPayment"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "isLocked"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-boolean v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 346
    iget-boolean v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    if-eqz v0, :cond_0

    .line 437
    :goto_0
    return-void

    .line 350
    :cond_0
    const-string v0, "IGGPayment"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "in pay prudctID = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 351
    iget-boolean v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isAvailable:Z

    if-nez v0, :cond_1

    .line 352
    const-string v0, "IGGPayment"

    const-string v1, "Please google play Payment initialized successfully, then initiate purchase"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 356
    :cond_1
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 357
    const/4 v7, 0x0

    .line 358
    .local v7, "bFound":Z
    const/4 v13, 0x0

    .line 364
    .local v13, "temp":Lcom/google/payment/Purchase;
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->ownedPurchase:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :cond_2
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_3

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/google/payment/Purchase;

    .line 365
    .local v6, "anOwnedPurchase":Lcom/google/payment/Purchase;
    move-object v13, v6

    .line 366
    const-string v1, "IGGPayment"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "The last  unconsumed product ID:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v13}, Lcom/google/payment/Purchase;->getSku()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 367
    invoke-virtual {v13}, Lcom/google/payment/Purchase;->getSku()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_2

    .line 368
    const/4 v7, 0x1

    .line 376
    .end local v6    # "anOwnedPurchase":Lcom/google/payment/Purchase;
    :cond_3
    if-eqz v7, :cond_4

    .line 377
    const-string v0, "IGGPayment"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "you have by the item just post to igg"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 378
    invoke-virtual {p0, v13}, Lcom/igg/sdk/payment/google/IGGPayment;->verifyConsumeFinished(Lcom/google/payment/Purchase;)V

    .line 436
    :goto_1
    const-string v0, "IGGPayment"

    const-string v1, "out pay"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 380
    :cond_4
    const-string v0, "IGGPayment"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "try to buy flow "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 381
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    if-eqz v0, :cond_b

    .line 383
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    invoke-virtual {v0}, Lcom/google/payment/IabHelper;->isAsyncInProgress()Z

    move-result v0

    if-eqz v0, :cond_5

    .line 384
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 385
    const-string v0, "IGGPayment"

    const-string v1, "There is  reasons: Last orders are consuming,please wait retry"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 386
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    const/4 v1, 0x0

    invoke-interface {v0, v1}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;->onIGGPurchaseStartingFinished(Z)V

    goto/16 :goto_0

    .line 392
    :cond_5
    :try_start_0
    new-instance v11, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;

    invoke-direct {v11}, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;-><init>()V

    .line 393
    .local v11, "payload":Lcom/igg/sdk/payment/bean/IGGPaymentPayload;
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getGameDelegate()Lcom/igg/sdk/IGGGameDelegate;

    move-result-object v10

    .line 395
    .local v10, "gameDelegate":Lcom/igg/sdk/IGGGameDelegate;
    const/4 v8, 0x0

    .line 396
    .local v8, "character":Lcom/igg/sdk/bean/IGGCharacter;
    if-eqz v10, :cond_6

    .line 397
    invoke-interface {v10}, Lcom/igg/sdk/IGGGameDelegate;->getCharacter()Lcom/igg/sdk/bean/IGGCharacter;

    move-result-object v8

    .line 400
    :cond_6
    if-eqz v8, :cond_7

    invoke-virtual {v8}, Lcom/igg/sdk/bean/IGGCharacter;->getCharId()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_7

    .line 401
    invoke-virtual {v8}, Lcom/igg/sdk/bean/IGGCharacter;->getCharId()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v11, v0}, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->setCharacterId(Ljava/lang/String;)V

    .line 404
    :cond_7
    const/4 v12, 0x0

    .line 405
    .local v12, "serverInfo":Lcom/igg/sdk/bean/IGGServerInfo;
    if-eqz v10, :cond_8

    .line 406
    invoke-interface {v10}, Lcom/igg/sdk/IGGGameDelegate;->getServerInfo()Lcom/igg/sdk/bean/IGGServerInfo;

    move-result-object v12

    .line 409
    :cond_8
    if-eqz v12, :cond_9

    invoke-virtual {v12}, Lcom/igg/sdk/bean/IGGServerInfo;->getServerId()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_9

    .line 410
    invoke-virtual {v12}, Lcom/igg/sdk/bean/IGGServerInfo;->getServerId()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v11, v0}, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->setServerId(Ljava/lang/String;)V

    .line 413
    :cond_9
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->iggId:Ljava/lang/String;

    invoke-virtual {v11, v0}, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->setIggId(Ljava/lang/String;)V

    .line 415
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->payType:Lcom/igg/sdk/IGGSDKConstant$orderType;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$orderType;->FRAUD_REPAY:Lcom/igg/sdk/IGGSDKConstant$orderType;

    if-ne v0, v1, :cond_a

    .line 416
    const-string v0, "5"

    invoke-virtual {v11, v0}, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->setOrderType(Ljava/lang/String;)V

    .line 417
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->rmId:Ljava/lang/String;

    invoke-virtual {v11, v0}, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->setRmId(Ljava/lang/String;)V

    .line 424
    :goto_2
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->activity:Landroid/app/Activity;

    const v3, 0xd1d2

    invoke-virtual {v11}, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->serialize()Ljava/lang/String;

    move-result-object v5

    move-object v2, p1

    move-object v4, p0

    invoke-virtual/range {v0 .. v5}, Lcom/google/payment/IabHelper;->launchPurchaseFlow(Landroid/app/Activity;Ljava/lang/String;ILcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_1

    .line 425
    .end local v8    # "character":Lcom/igg/sdk/bean/IGGCharacter;
    .end local v10    # "gameDelegate":Lcom/igg/sdk/IGGGameDelegate;
    .end local v11    # "payload":Lcom/igg/sdk/payment/bean/IGGPaymentPayload;
    .end local v12    # "serverInfo":Lcom/igg/sdk/bean/IGGServerInfo;
    :catch_0
    move-exception v9

    .line 426
    .local v9, "e":Ljava/lang/Exception;
    invoke-virtual {v9}, Ljava/lang/Exception;->printStackTrace()V

    .line 427
    const-string v0, "IGGPayment"

    const-string v1, "Error launching purchase flow. Another async operation in progress."

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 428
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    sget-object v1, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_PURCHASE:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    const/4 v2, 0x0

    invoke-interface {v0, v1, v2}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;->onIGGPurchaseFailed(Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;Lcom/google/payment/Purchase;)V

    .line 429
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    goto/16 :goto_1

    .line 419
    .end local v9    # "e":Ljava/lang/Exception;
    .restart local v8    # "character":Lcom/igg/sdk/bean/IGGCharacter;
    .restart local v10    # "gameDelegate":Lcom/igg/sdk/IGGGameDelegate;
    .restart local v11    # "payload":Lcom/igg/sdk/payment/bean/IGGPaymentPayload;
    .restart local v12    # "serverInfo":Lcom/igg/sdk/bean/IGGServerInfo;
    :cond_a
    :try_start_1
    const-string v0, "1"

    invoke-virtual {v11, v0}, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->setOrderType(Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_2

    .line 432
    .end local v8    # "character":Lcom/igg/sdk/bean/IGGCharacter;
    .end local v10    # "gameDelegate":Lcom/igg/sdk/IGGGameDelegate;
    .end local v11    # "payload":Lcom/igg/sdk/payment/bean/IGGPaymentPayload;
    .end local v12    # "serverInfo":Lcom/igg/sdk/bean/IGGServerInfo;
    :cond_b
    const-string v0, "IGGPayment"

    const-string v1, "There is reasons: Payment initialization failed"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_1
.end method


# virtual methods
.method public finalize()V
    .locals 4

    .prologue
    .line 223
    :try_start_0
    invoke-super {p0}, Ljava/lang/Object;->finalize()V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 228
    :goto_0
    :try_start_1
    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->mBroadcastReceiver:Lcom/google/payment/IabBroadcastReceiver;

    if-eqz v2, :cond_0

    .line 229
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPayment;->mBroadcastReceiver:Lcom/google/payment/IabBroadcastReceiver;

    invoke-virtual {v2, v3}, Landroid/app/Application;->unregisterReceiver(Landroid/content/BroadcastReceiver;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    .line 235
    :cond_0
    :goto_1
    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->manager:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    if-eqz v2, :cond_1

    .line 236
    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->manager:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-virtual {v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->destroy()V

    .line 239
    :cond_1
    const-string v2, "IGGPayment"

    const-string v3, "Destroying helper."

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 240
    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    if-eqz v2, :cond_2

    .line 241
    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    invoke-virtual {v2}, Lcom/google/payment/IabHelper;->disposeWhenFinished()V

    .line 242
    const/4 v2, 0x0

    iput-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    .line 244
    :cond_2
    return-void

    .line 224
    :catch_0
    move-exception v1

    .line 225
    .local v1, "throwable":Ljava/lang/Throwable;
    invoke-virtual {v1}, Ljava/lang/Throwable;->printStackTrace()V

    goto :goto_0

    .line 231
    .end local v1    # "throwable":Ljava/lang/Throwable;
    :catch_1
    move-exception v0

    .line 232
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_1
.end method

.method public fraudPay(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "itemId"    # Ljava/lang/String;
    .param p2, "urId"    # Ljava/lang/String;

    .prologue
    .line 315
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$orderType;->FRAUD_REPAY:Lcom/igg/sdk/IGGSDKConstant$orderType;

    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->payType:Lcom/igg/sdk/IGGSDKConstant$orderType;

    .line 316
    iput-object p2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->rmId:Ljava/lang/String;

    .line 317
    invoke-direct {p0, p1}, Lcom/igg/sdk/payment/google/IGGPayment;->startPay(Ljava/lang/String;)V

    .line 318
    return-void
.end method

.method public getGameId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 684
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->gameId:Ljava/lang/String;

    return-object v0
.end method

.method public getIABHelper()Lcom/google/payment/IabHelper;
    .locals 1

    .prologue
    .line 259
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    return-object v0
.end method

.method public getIggId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 692
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->iggId:Ljava/lang/String;

    return-object v0
.end method

.method public getPurchaseLimit()I
    .locals 1

    .prologue
    .line 700
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->manager:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-virtual {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->getPurchaseLimit()I

    move-result v0

    return v0
.end method

.method public initialize(Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;)V
    .locals 2
    .param p1, "listener"    # Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    .prologue
    .line 191
    const-string v0, "IGGPayment"

    const-string v1, "in initPayHelper"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 192
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->ownedPurchase:Ljava/util/List;

    .line 193
    iput-object p1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    .line 196
    const-string v0, "IGGPayment"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getPaymentKey()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 197
    invoke-static {}, Lcom/google/payment/IabHelper;->sharedInstance()Lcom/google/payment/IabHelper;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    .line 198
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->activity:Landroid/app/Activity;

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->setContext(Landroid/content/Context;)V

    .line 199
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getPaymentKey()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->setSignatureBase64(Ljava/lang/String;)V

    .line 200
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->paymentType:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->BAZAAR:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    if-ne v0, v1, :cond_0

    .line 202
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->BAZAAR:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->setPaymentType(Lcom/igg/sdk/IGGSDKConstant$PaymentType;)V

    .line 209
    :goto_0
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->enableDebugLogging(Z)V

    .line 211
    const-string v0, "IGGPayment"

    const-string v1, "Try to Starting IAP setup."

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 212
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    invoke-virtual {v0, p0}, Lcom/google/payment/IabHelper;->startSetup(Lcom/google/payment/IabHelper$OnIabSetupFinishedListener;)V

    .line 214
    const-string v0, "IGGPayment"

    const-string v1, "out initPayHelper"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 215
    return-void

    .line 204
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->setPaymentType(Lcom/igg/sdk/IGGSDKConstant$PaymentType;)V

    goto :goto_0
.end method

.method public isAvailable()Z
    .locals 1

    .prologue
    .line 252
    iget-boolean v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isAvailable:Z

    return v0
.end method

.method public loadItems(Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;)Z
    .locals 1
    .param p1, "listener"    # Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    .prologue
    .line 269
    const-string v0, "android"

    invoke-virtual {p0, v0, p1}, Lcom/igg/sdk/payment/google/IGGPayment;->loadItems(Ljava/lang/String;Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;)Z

    move-result v0

    return v0
.end method

.method public loadItems(Ljava/lang/String;Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;)Z
    .locals 1
    .param p1, "channelName"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    .prologue
    .line 279
    const/4 v0, 0x0

    invoke-virtual {p0, p1, v0, p2}, Lcom/igg/sdk/payment/google/IGGPayment;->loadItems(Ljava/lang/String;ZLcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;)Z

    move-result v0

    return v0
.end method

.method public loadItems(Ljava/lang/String;ZLcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;)Z
    .locals 2
    .param p1, "channelName"    # Ljava/lang/String;
    .param p2, "ifGetGooglePlayPrice"    # Z
    .param p3, "listener"    # Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    .prologue
    .line 293
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->prevIGGId:Ljava/lang/String;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->iggId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 294
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->iggId:Ljava/lang/String;

    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->prevIGGId:Ljava/lang/String;

    .line 296
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->manager:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    if-eqz v0, :cond_0

    .line 297
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->manager:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-virtual {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->destroy()V

    .line 300
    :cond_0
    new-instance v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-direct {v0, p1, p2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;-><init>(Ljava/lang/String;Z)V

    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->manager:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .line 302
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->manager:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-virtual {v0, p1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->setChannelName(Ljava/lang/String;)V

    .line 303
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->manager:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    invoke-virtual {v0, p2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->setGetGooglePlayPrice(Z)V

    .line 305
    :cond_1
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->manager:Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->iggId:Ljava/lang/String;

    invoke-virtual {v0, v1, p3}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadItems(Ljava/lang/String;Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;)Z

    move-result v0

    return v0
.end method

.method public onConsumeFinished(Lcom/google/payment/Purchase;Lcom/google/payment/IabResult;)V
    .locals 3
    .param p1, "purchase"    # Lcom/google/payment/Purchase;
    .param p2, "result"    # Lcom/google/payment/IabResult;

    .prologue
    const/4 v2, 0x0

    .line 643
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    if-nez v1, :cond_0

    .line 678
    :goto_0
    return-void

    .line 645
    :cond_0
    invoke-virtual {p2}, Lcom/google/payment/IabResult;->isSuccess()Z

    move-result v1

    if-eqz v1, :cond_2

    .line 659
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->ownedPurchase:Ljava/util/List;

    invoke-interface {v1, p1}, Ljava/util/List;->remove(Ljava/lang/Object;)Z

    .line 660
    iput-boolean v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 662
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->ownedPurchase:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v0

    .line 663
    .local v0, "endUnconsumeCount":I
    if-lez v0, :cond_1

    .line 665
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->ownedPurchase:Ljava/util/List;

    invoke-interface {v1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/google/payment/Purchase;

    invoke-virtual {p0, v1}, Lcom/igg/sdk/payment/google/IGGPayment;->verifyConsumeFinished(Lcom/google/payment/Purchase;)V

    .line 668
    :cond_1
    const-string v1, "IGGPayment"

    const-string v2, "Purchase successful."

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 677
    .end local v0    # "endUnconsumeCount":I
    :goto_1
    const-string v1, "IGGPayment"

    const-string v2, "out OnConsumeFinishedListener"

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 670
    :cond_2
    iput-boolean v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 674
    const-string v1, "IGGPayment"

    const-string v2, "onConsumeFinished consume failed"

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1
.end method

.method public onIGGPurchaseSubmittalFinished(ZZLcom/google/payment/Purchase;)V
    .locals 5
    .param p1, "success"    # Z
    .param p2, "accepted"    # Z
    .param p3, "purchase"    # Lcom/google/payment/Purchase;

    .prologue
    const/4 v4, 0x0

    .line 600
    if-eqz p1, :cond_1

    .line 601
    const-string v1, "IGGPayment"

    const-string v2, "IABHandler.sendMessage PURCHASE_START_CONSUME"

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 606
    if-eqz p2, :cond_0

    .line 607
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    const/4 v2, 0x1

    invoke-static {v2}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v2

    invoke-interface {v1, p3, v2}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;->onIGGPurchaseFinished(Lcom/google/payment/Purchase;Ljava/lang/Boolean;)V

    .line 613
    :goto_0
    :try_start_0
    const-string v1, "IGGPayment"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "isLocked===onIGGPurchaseSubmittalFinished= accepted=="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    iget-boolean v3, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 614
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    invoke-virtual {v1, p3, p0}, Lcom/google/payment/IabHelper;->consumeAsync(Lcom/google/payment/Purchase;Lcom/google/payment/IabHelper$OnConsumeFinishedListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 630
    :goto_1
    return-void

    .line 609
    :cond_0
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    invoke-static {v4}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v2

    invoke-interface {v1, p3, v2}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;->onIGGPurchaseFinished(Lcom/google/payment/Purchase;Ljava/lang/Boolean;)V

    goto :goto_0

    .line 615
    :catch_0
    move-exception v0

    .line 616
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    .line 618
    const-string v1, "IGGPayment"

    const-string v2, "Error consuming gas. Another async operation in progress."

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 619
    iput-boolean v4, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    goto :goto_1

    .line 625
    .end local v0    # "e":Ljava/lang/Exception;
    :cond_1
    iput-boolean v4, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 627
    const-string v1, "IGGPayment"

    const-string v2, "onIGGPurchaseSubmittalFinished success:false isLockedfalse"

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 628
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    sget-object v2, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IGG_GATEWAY:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    invoke-interface {v1, v2, p3}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;->onIGGPurchaseFailed(Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;Lcom/google/payment/Purchase;)V

    goto :goto_1
.end method

.method public onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V
    .locals 3
    .param p1, "result"    # Lcom/google/payment/IabResult;
    .param p2, "purchase"    # Lcom/google/payment/Purchase;

    .prologue
    .line 572
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    if-nez v0, :cond_0

    .line 592
    :goto_0
    return-void

    .line 574
    :cond_0
    invoke-virtual {p1}, Lcom/google/payment/IabResult;->isFailure()Z

    move-result v0

    if-eqz v0, :cond_2

    .line 575
    const-string v0, "IGGPayment"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Error purchasing: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 576
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 577
    invoke-virtual {p1}, Lcom/google/payment/IabResult;->getResponse()I

    move-result v0

    const/16 v1, -0x3ed

    if-ne v0, v1, :cond_1

    .line 578
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    sget-object v1, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_CANCELED:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    invoke-interface {v0, v1, p2}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;->onIGGPurchaseFailed(Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;Lcom/google/payment/Purchase;)V

    goto :goto_0

    .line 580
    :cond_1
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    sget-object v1, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;->IAB_PURCHASE:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;

    invoke-interface {v0, v1, p2}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;->onIGGPurchaseFailed(Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseFailureType;Lcom/google/payment/Purchase;)V

    goto :goto_0

    .line 585
    :cond_2
    const-string v0, "IGGPayment"

    const-string v1, "Purchase successful try to post to igg"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 587
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->ownedPurchase:Ljava/util/List;

    invoke-interface {v0, p2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 589
    invoke-virtual {p0, p2}, Lcom/igg/sdk/payment/google/IGGPayment;->verifyConsumeFinished(Lcom/google/payment/Purchase;)V

    .line 591
    const-string v0, "IGGPayment"

    const-string v1, "out OnIabPurchaseFinishedListener"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public onIabSetupFinished(Lcom/google/payment/IabResult;)V
    .locals 6
    .param p1, "result"    # Lcom/google/payment/IabResult;

    .prologue
    const/4 v4, 0x1

    const/4 v5, 0x0

    .line 478
    const-string v2, "IGGPayment"

    const-string v3, "in onIabSetupFinished"

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 479
    iput-boolean v4, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 480
    invoke-virtual {p1}, Lcom/google/payment/IabResult;->isSuccess()Z

    move-result v2

    if-nez v2, :cond_1

    .line 482
    const-string v2, "IGGPayment"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "Problem setting up in-app billing: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 484
    iput-boolean v5, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 486
    const-string v2, "IGGPayment"

    const-string v3, "Payment initialization failed,Please check install a new version of Google Play and make sure your system version largers than 2.2 please and  whether the network is limited and whether this configuration google play account"

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 489
    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "Run function onIabSetupFinished() fails.Problem setting up in-app billing: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-interface {v2, v5, v3}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;->onIGGPurchasePreparingFinished(ZLjava/lang/String;)V

    .line 518
    :cond_0
    :goto_0
    return-void

    .line 494
    :cond_1
    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    if-eqz v2, :cond_0

    .line 496
    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->purchaseListener:Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;

    const/4 v3, 0x0

    invoke-interface {v2, v4, v3}, Lcom/igg/sdk/payment/google/IGGPayment$IGGPurchaseListener;->onIGGPurchasePreparingFinished(ZLjava/lang/String;)V

    .line 499
    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->mBroadcastReceiver:Lcom/google/payment/IabBroadcastReceiver;

    if-nez v2, :cond_2

    .line 500
    const-string v2, "IGGPayment"

    const-string v3, "mBroadcastReceiver register"

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 501
    new-instance v2, Lcom/google/payment/IabBroadcastReceiver;

    invoke-direct {v2, p0}, Lcom/google/payment/IabBroadcastReceiver;-><init>(Lcom/google/payment/IabBroadcastReceiver$IabBroadcastListener;)V

    iput-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->mBroadcastReceiver:Lcom/google/payment/IabBroadcastReceiver;

    .line 502
    new-instance v0, Landroid/content/IntentFilter;

    const-string v2, "com.android.vending.billing.PURCHASES_UPDATED"

    invoke-direct {v0, v2}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    .line 503
    .local v0, "broadcastFilter":Landroid/content/IntentFilter;
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPayment;->mBroadcastReceiver:Lcom/google/payment/IabBroadcastReceiver;

    invoke-virtual {v2, v3, v0}, Landroid/app/Application;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    .line 506
    .end local v0    # "broadcastFilter":Landroid/content/IntentFilter;
    :cond_2
    const-string v2, "IGGPayment"

    const-string v3, "Setup successful. Querying inventory."

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 508
    iput-boolean v4, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isAvailable:Z

    .line 510
    :try_start_0
    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    invoke-virtual {v2, p0}, Lcom/google/payment/IabHelper;->queryInventoryAsync(Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 517
    :goto_1
    const-string v2, "IGGPayment"

    const-string v3, "out onIabSetupFinished"

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 511
    :catch_0
    move-exception v1

    .line 512
    .local v1, "e":Ljava/lang/Exception;
    iput-boolean v5, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 513
    const-string v2, "IGGPayment"

    invoke-virtual {v1}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 514
    const-string v2, "IGGPayment"

    const-string v3, "Error querying inventory. Another async operation in progress."

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1
.end method

.method public onQueryInventoryFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Inventory;)V
    .locals 4
    .param p1, "result"    # Lcom/google/payment/IabResult;
    .param p2, "inventory"    # Lcom/google/payment/Inventory;

    .prologue
    const/4 v3, 0x0

    .line 524
    const-string v1, "IGGPayment"

    const-string v2, "in QueryInventoryFinishedListener"

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 526
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    if-nez v1, :cond_0

    .line 547
    :goto_0
    return-void

    .line 529
    :cond_0
    invoke-virtual {p1}, Lcom/google/payment/IabResult;->isFailure()Z

    move-result v1

    if-eqz v1, :cond_1

    .line 530
    const-string v1, "IGGPayment"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Failed to query inventory: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 532
    const-string v1, "IGGPayment"

    const-string v2, "Last items consumed failure,Please Check whether the network is limited"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 537
    :cond_1
    invoke-virtual {p2}, Lcom/google/payment/Inventory;->getAllPurchases()Ljava/util/List;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->ownedPurchase:Ljava/util/List;

    .line 539
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->ownedPurchase:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    if-lez v1, :cond_2

    .line 540
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->ownedPurchase:Ljava/util/List;

    invoke-interface {v1, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/payment/Purchase;

    .line 541
    .local v0, "purchase":Lcom/google/payment/Purchase;
    invoke-virtual {p0, v0}, Lcom/igg/sdk/payment/google/IGGPayment;->verifyConsumeFinished(Lcom/google/payment/Purchase;)V

    .line 546
    .end local v0    # "purchase":Lcom/google/payment/Purchase;
    :goto_1
    const-string v1, "IGGPayment"

    const-string v2, "out QueryInventoryFinishedListener"

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 543
    :cond_2
    iput-boolean v3, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    goto :goto_1
.end method

.method public pay(Ljava/lang/String;)V
    .locals 1
    .param p1, "prudctID"    # Ljava/lang/String;

    .prologue
    .line 334
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$orderType;->NORMAL:Lcom/igg/sdk/IGGSDKConstant$orderType;

    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->payType:Lcom/igg/sdk/IGGSDKConstant$orderType;

    .line 335
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->rmId:Ljava/lang/String;

    .line 336
    invoke-direct {p0, p1}, Lcom/igg/sdk/payment/google/IGGPayment;->startPay(Ljava/lang/String;)V

    .line 337
    return-void
.end method

.method public receivedBroadcast()V
    .locals 3

    .prologue
    .line 448
    const-string v1, "IGGPayment"

    const-string v2, "Received broadcast notification. Querying inventory."

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 450
    :try_start_0
    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->helper:Lcom/google/payment/IabHelper;

    invoke-virtual {v1, p0}, Lcom/google/payment/IabHelper;->queryInventoryAsync(Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;)V
    :try_end_0
    .catch Lcom/google/payment/IabHelper$IabAsyncInProgressException; {:try_start_0 .. :try_end_0} :catch_0

    .line 454
    :goto_0
    return-void

    .line 451
    :catch_0
    move-exception v0

    .line 452
    .local v0, "e":Lcom/google/payment/IabHelper$IabAsyncInProgressException;
    const-string v1, "IGGPayment"

    const-string v2, "**** TrivialDrive Error: Error querying inventory. Another async operation in progress."

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public setGameId(Ljava/lang/String;)V
    .locals 0
    .param p1, "gameId"    # Ljava/lang/String;

    .prologue
    .line 688
    iput-object p1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->gameId:Ljava/lang/String;

    .line 689
    return-void
.end method

.method public setIggId(Ljava/lang/String;)V
    .locals 0
    .param p1, "iggId"    # Ljava/lang/String;

    .prologue
    .line 696
    iput-object p1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->iggId:Ljava/lang/String;

    .line 697
    return-void
.end method

.method public verifyConsumeFinished(Lcom/google/payment/Purchase;)V
    .locals 7
    .param p1, "purchase"    # Lcom/google/payment/Purchase;

    .prologue
    .line 554
    if-eqz p1, :cond_0

    .line 555
    const/4 v0, 0x1

    :try_start_0
    iput-boolean v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 557
    new-instance v0, Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-direct {v0}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPayment;->paymentType:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPayment;->gameId:Ljava/lang/String;

    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPayment;->iggId:Ljava/lang/String;

    move-object v2, p1

    move-object v5, p0

    invoke-virtual/range {v0 .. v5}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->submit(Lcom/igg/sdk/IGGSDKConstant$PaymentType;Lcom/google/payment/Purchase;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 563
    :cond_0
    :goto_0
    return-void

    .line 559
    :catch_0
    move-exception v6

    .line 560
    .local v6, "e":Ljava/lang/Exception;
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/sdk/payment/google/IGGPayment;->isLocked:Z

    .line 561
    const-string v0, "IGGPayment"

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method
