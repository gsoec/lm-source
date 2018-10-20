.class public Lcom/igg/iggsdkbusiness/ProuductWeChat;
.super Ljava/lang/Object;
.source "ProuductWeChat.java"


# static fields
.field public static final IGGPaymentPurchaseLimitationBoth:I = 0x3

.field public static final IGGPaymentPurchaseLimitationDevice:I = 0x2

.field public static final IGGPaymentPurchaseLimitationNone:I = 0x0

.field public static final IGGPaymentPurchaseLimitationUser:I = 0x1

.field public static final TAG:Ljava/lang/String; = "ProuductWeChat"

.field private static instance:Lcom/igg/iggsdkbusiness/ProuductWeChat;


# instance fields
.field public AliPayCallBackCencel:Ljava/lang/String;

.field public AliPayCallBackFailed:Ljava/lang/String;

.field public AliPayCallBackSuccessful:Ljava/lang/String;

.field public AliPayConfirming:Ljava/lang/String;

.field public AmoutOfLimitCallBack:Ljava/lang/String;

.field public AmoutOfLimitErrorCallBack:Ljava/lang/String;

.field ErrorPaymentFailed:Ljava/lang/String;

.field ErrorPaymentIsNotReady:Ljava/lang/String;

.field IGGID:Ljava/lang/String;

.field PaymentSuccessful:Ljava/lang/String;

.field PurchaseLimitCallBack:Ljava/lang/String;

.field public WeChatPatCallBackCencel:Ljava/lang/String;

.field public WeChatPayCallBackFailed:Ljava/lang/String;

.field public WeChatPayCallBackSuccessful:Ljava/lang/String;

.field alipayHelp:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

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

.field private payInfo:Lcom/igg/sdk/service/IGGPaymentService;

.field paySuccessCallBack:Ljava/lang/String;

.field private paymentReady:Z

.field preparingFailedCallBack:Ljava/lang/String;

.field private purchaseLimit:I

.field purchaseStartingFailedCallBack:Ljava/lang/String;

.field setFailedCallBack:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    const/4 v0, 0x0

    .line 38
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 33
    iput-boolean v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->paymentReady:Z

    .line 35
    iput v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    .line 42
    const-string v0, "purchaseStartingFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseStartingFailedCallBack:Ljava/lang/String;

    .line 44
    const-string v0, "setFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->setFailedCallBack:Ljava/lang/String;

    .line 46
    const-string v0, "preparingPaymentFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->preparingFailedCallBack:Ljava/lang/String;

    .line 48
    const-string v0, "paySuccessCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->paySuccessCallBack:Ljava/lang/String;

    .line 50
    const-string v0, "payGatewayFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->payGatewayFailedCallBack:Ljava/lang/String;

    .line 52
    const-string v0, "payFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->payFailedCallBack:Ljava/lang/String;

    .line 54
    const-string v0, "getProductCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->getProductCallBack:Ljava/lang/String;

    .line 56
    const-string v0, "payCancelCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->payCancelCallBack:Ljava/lang/String;

    .line 58
    const-string v0, "PurchaseLimitCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    .line 61
    const-string v0, "WeChatPayCallBackFailed"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPayCallBackFailed:Ljava/lang/String;

    .line 62
    const-string v0, "WeChatPayCallBackSuccessful"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPayCallBackSuccessful:Ljava/lang/String;

    .line 63
    const-string v0, "WeChatPatCallBackCencel"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPatCallBackCencel:Ljava/lang/String;

    .line 65
    const-string v0, "AliPayCallBackFailed"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPayCallBackFailed:Ljava/lang/String;

    .line 66
    const-string v0, "AliPayCallBackSuccessful"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPayCallBackSuccessful:Ljava/lang/String;

    .line 67
    const-string v0, "AliPayConfirming"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPayConfirming:Ljava/lang/String;

    .line 68
    const-string v0, "AmoutOfLimitFailed"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AmoutOfLimitCallBack:Ljava/lang/String;

    .line 69
    const-string v0, "AmoutOfLimitErrorFailed"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AmoutOfLimitErrorCallBack:Ljava/lang/String;

    .line 70
    const-string v0, "AliPayCallBackCencel"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPayCallBackCencel:Ljava/lang/String;

    .line 72
    const-string v0, "1883"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->ErrorPaymentIsNotReady:Ljava/lang/String;

    .line 73
    const-string v0, "1873"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->ErrorPaymentFailed:Ljava/lang/String;

    .line 74
    const-string v0, "1872"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PaymentSuccessful:Ljava/lang/String;

    .line 39
    return-void
.end method

.method static synthetic access$000(Lcom/igg/iggsdkbusiness/ProuductWeChat;Ljava/util/List;)Ljava/lang/String;
    .locals 1
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/ProuductWeChat;
    .param p1, "x1"    # Ljava/util/List;

    .prologue
    .line 26
    invoke-direct {p0, p1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->getProductTitles(Ljava/util/List;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$102(Lcom/igg/iggsdkbusiness/ProuductWeChat;Z)Z
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/ProuductWeChat;
    .param p1, "x1"    # Z

    .prologue
    .line 26
    iput-boolean p1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->paymentReady:Z

    return p1
.end method

.method static synthetic access$202(Lcom/igg/iggsdkbusiness/ProuductWeChat;I)I
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/ProuductWeChat;
    .param p1, "x1"    # I

    .prologue
    .line 26
    iput p1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

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
    .line 154
    .local p1, "items":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    const-string v8, "WeChatPay"

    const-string v9, "getProductTitles"

    invoke-static {v8, v9}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 155
    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    iput-object v8, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->itemIds:Ljava/util/ArrayList;

    .line 156
    new-instance v7, Ljava/lang/String;

    invoke-direct {v7}, Ljava/lang/String;-><init>()V

    .line 157
    .local v7, "str":Ljava/lang/String;
    const/4 v2, 0x0

    .local v2, "i":I
    :goto_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v8

    if-ge v2, v8, :cond_0

    .line 158
    invoke-interface {p1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/igg/sdk/payment/bean/IGGGameItem;

    .line 161
    .local v3, "item":Lcom/igg/sdk/payment/bean/IGGGameItem;
    const-string v1, ""

    .line 164
    .local v1, "googlePrice":Ljava/lang/String;
    :try_start_0
    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v8

    sget-object v9, Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;->RMB:Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;

    invoke-virtual {v8, v9}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->setCurrency(Lcom/igg/sdk/payment/bean/IGGCurrency$Currency;)V

    .line 166
    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v8

    invoke-virtual {v8}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->getFormattedPrice()Ljava/lang/String;

    move-result-object v6

    .line 171
    .local v6, "price":Ljava/lang/String;
    const-string v8, "ProductTitles"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v9, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v9

    const-string v10, "."

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v3}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getId()Ljava/lang/Integer;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v9

    const-string v10, "_price = "

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 178
    :goto_1
    :try_start_1
    const-string v5, ""

    .line 179
    .local v5, "pStartContext":Ljava/lang/String;
    const-string v4, ""

    .line 180
    .local v4, "pEndContext":Ljava/lang/String;
    const-string v5, "{"

    .line 181
    const-string v4, "}"

    .line 182
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

    .line 183
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
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    move-result-object v7

    .line 157
    .end local v4    # "pEndContext":Ljava/lang/String;
    .end local v5    # "pStartContext":Ljava/lang/String;
    :goto_2
    add-int/lit8 v2, v2, 0x1

    goto/16 :goto_0

    .line 172
    .end local v6    # "price":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 173
    .local v0, "e":Ljava/lang/Exception;
    const-string v6, "0"

    .line 174
    .restart local v6    # "price":Ljava/lang/String;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto/16 :goto_1

    .line 185
    .end local v0    # "e":Ljava/lang/Exception;
    :catch_1
    move-exception v0

    .line 186
    .restart local v0    # "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_2

    .line 192
    .end local v0    # "e":Ljava/lang/Exception;
    .end local v1    # "googlePrice":Ljava/lang/String;
    .end local v3    # "item":Lcom/igg/sdk/payment/bean/IGGGameItem;
    .end local v6    # "price":Ljava/lang/String;
    :cond_0
    return-object v7
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/ProuductWeChat;
    .locals 1

    .prologue
    .line 77
    sget-object v0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->instance:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    if-nez v0, :cond_0

    .line 78
    new-instance v0, Lcom/igg/iggsdkbusiness/ProuductWeChat;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/ProuductWeChat;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->instance:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    .line 80
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->instance:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    return-object v0
.end method


# virtual methods
.method public AliPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 7
    .param p1, "pic_id"    # Ljava/lang/String;
    .param p2, "subject"    # Ljava/lang/String;
    .param p3, "body"    # Ljava/lang/String;
    .param p4, "price"    # Ljava/lang/String;

    .prologue
    .line 433
    iget-boolean v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->paymentReady:Z

    if-nez v0, :cond_0

    .line 435
    const-string v0, "ProuductWeChat"

    const-string v1, "paymentNotReady"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 437
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->preparingFailedCallBack:Ljava/lang/String;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->ErrorPaymentIsNotReady:Ljava/lang/String;

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 481
    :goto_0
    return-void

    .line 441
    :cond_0
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_1

    .line 442
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8d26\u53f7\u548c\u8bbe\u5907\u90fd\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 443
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "3"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 447
    :cond_1
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 448
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8bbe\u5907\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 449
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "1"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 453
    :cond_2
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_3

    .line 454
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8d26\u53f7\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 455
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "2"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 458
    :cond_3
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->alipayHelp:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    const-string v5, "1"

    new-instance v6, Lcom/igg/iggsdkbusiness/ProuductWeChat$5;

    invoke-direct {v6, p0}, Lcom/igg/iggsdkbusiness/ProuductWeChat$5;-><init>(Lcom/igg/iggsdkbusiness/ProuductWeChat;)V

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    invoke-virtual/range {v0 .. v6}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->pay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V

    goto :goto_0
.end method

.method public AliPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZF)V
    .locals 9
    .param p1, "pic_id"    # Ljava/lang/String;
    .param p2, "subject"    # Ljava/lang/String;
    .param p3, "body"    # Ljava/lang/String;
    .param p4, "price"    # Ljava/lang/String;
    .param p5, "isEnableAntiAddiction"    # Z
    .param p6, "amoutOfLimit"    # F

    .prologue
    .line 485
    iget-boolean v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->paymentReady:Z

    if-nez v0, :cond_0

    .line 487
    const-string v0, "ProuductWeChat"

    const-string v1, "paymentNotReady"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 489
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->preparingFailedCallBack:Ljava/lang/String;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->ErrorPaymentIsNotReady:Ljava/lang/String;

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 550
    :goto_0
    return-void

    .line 493
    :cond_0
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_1

    .line 494
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8d26\u53f7\u548c\u8bbe\u5907\u90fd\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 495
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "3"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 499
    :cond_1
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 500
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8bbe\u5907\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 501
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "1"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 505
    :cond_2
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_3

    .line 506
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8d26\u53f7\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 507
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "2"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 511
    :cond_3
    new-instance v6, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;

    invoke-direct {v6}, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;-><init>()V

    .line 512
    .local v6, "restriction":Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;
    invoke-virtual {v6, p5}, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->setAntiAddictionEnable(Z)V

    .line 513
    invoke-virtual {v6, p6}, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->setAntiAddictionPeriodCostQuota(F)V

    .line 514
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->alipayHelp:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    const-string v5, "1"

    new-instance v7, Lcom/igg/iggsdkbusiness/ProuductWeChat$6;

    invoke-direct {v7, p0}, Lcom/igg/iggsdkbusiness/ProuductWeChat$6;-><init>(Lcom/igg/iggsdkbusiness/ProuductWeChat;)V

    new-instance v8, Lcom/igg/iggsdkbusiness/ProuductWeChat$7;

    invoke-direct {v8, p0}, Lcom/igg/iggsdkbusiness/ProuductWeChat$7;-><init>(Lcom/igg/iggsdkbusiness/ProuductWeChat;)V

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    invoke-virtual/range {v0 .. v8}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->pay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;)V

    goto :goto_0
.end method

.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 90
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 91
    return-void
.end method

.method public IsPaymentReady()Z
    .locals 1

    .prologue
    .line 197
    iget-boolean v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->paymentReady:Z

    return v0
.end method

.method public WeChatPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 7
    .param p1, "itemId"    # Ljava/lang/String;
    .param p2, "itemName"    # Ljava/lang/String;
    .param p3, "price"    # Ljava/lang/String;

    .prologue
    .line 225
    iget-boolean v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->paymentReady:Z

    if-nez v0, :cond_0

    .line 227
    const-string v0, "ProuductWeChat"

    const-string v1, "paymentNotReady"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 229
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->preparingFailedCallBack:Ljava/lang/String;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->ErrorPaymentIsNotReady:Ljava/lang/String;

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 316
    :goto_0
    return-void

    .line 233
    :cond_0
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_1

    .line 234
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8d26\u53f7\u548c\u8bbe\u5907\u90fd\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 235
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "3"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 239
    :cond_1
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 240
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8bbe\u5907\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 241
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "1"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 245
    :cond_2
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_3

    .line 246
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8d26\u53f7\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 247
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "2"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 250
    :cond_3
    const-string v0, "WeChatPay"

    const-string v1, "Pay"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 251
    const-string v0, "WeChatPay"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "itemId = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "itemName = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "price = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 252
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->payInfo:Lcom/igg/sdk/service/IGGPaymentService;

    const-string v5, "1"

    new-instance v6, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;

    invoke-direct {v6, p0}, Lcom/igg/iggsdkbusiness/ProuductWeChat$2;-><init>(Lcom/igg/iggsdkbusiness/ProuductWeChat;)V

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    invoke-virtual/range {v0 .. v6}, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatPayment(Lcom/igg/sdk/service/IGGPaymentService;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V

    goto/16 :goto_0
.end method

.method public WeChatPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZF)V
    .locals 9
    .param p1, "itemId"    # Ljava/lang/String;
    .param p2, "itemName"    # Ljava/lang/String;
    .param p3, "price"    # Ljava/lang/String;
    .param p4, "isEnableAntiAddiction"    # Z
    .param p5, "amoutOfLimit"    # F

    .prologue
    .line 319
    iget-boolean v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->paymentReady:Z

    if-nez v0, :cond_0

    .line 321
    const-string v0, "ProuductWeChat"

    const-string v1, "paymentNotReady"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 323
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->preparingFailedCallBack:Ljava/lang/String;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->ErrorPaymentIsNotReady:Ljava/lang/String;

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 426
    :goto_0
    return-void

    .line 327
    :cond_0
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_1

    .line 328
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8d26\u53f7\u548c\u8bbe\u5907\u90fd\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 329
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "3"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 333
    :cond_1
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_2

    .line 334
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8bbe\u5907\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 335
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "1"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 339
    :cond_2
    iget v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->purchaseLimit:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_3

    .line 340
    const-string v0, "ProuductWeChat"

    const-string v1, "\u8d26\u53f7\u88ab\u9650\u5236\u8d2d\u4e70"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 341
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->PurchaseLimitCallBack:Ljava/lang/String;

    const-string v1, "2"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 344
    :cond_3
    const-string v0, "WeChatPay"

    const-string v1, "Pay"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 345
    const-string v0, "WeChatPay"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "itemId = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "itemName = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "price = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 347
    new-instance v6, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;

    invoke-direct {v6}, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;-><init>()V

    .line 348
    .local v6, "restriction":Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;
    invoke-virtual {v6, p4}, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->setAntiAddictionEnable(Z)V

    .line 349
    invoke-virtual {v6, p5}, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->setAntiAddictionPeriodCostQuota(F)V

    .line 351
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->payInfo:Lcom/igg/sdk/service/IGGPaymentService;

    const-string v5, "1"

    new-instance v7, Lcom/igg/iggsdkbusiness/ProuductWeChat$3;

    invoke-direct {v7, p0}, Lcom/igg/iggsdkbusiness/ProuductWeChat$3;-><init>(Lcom/igg/iggsdkbusiness/ProuductWeChat;)V

    new-instance v8, Lcom/igg/iggsdkbusiness/ProuductWeChat$4;

    invoke-direct {v8, p0}, Lcom/igg/iggsdkbusiness/ProuductWeChat$4;-><init>(Lcom/igg/iggsdkbusiness/ProuductWeChat;)V

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    invoke-virtual/range {v0 .. v8}, Lcom/igg/iggsdkbusiness/WeChatHelper;->weChatPayment(Lcom/igg/sdk/service/IGGPaymentService;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;)V

    goto/16 :goto_0
.end method

.method getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 205
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method public getProduct()V
    .locals 3

    .prologue
    .line 98
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->IGGID:Ljava/lang/String;

    if-nez v1, :cond_0

    .line 99
    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->IGGID:Ljava/lang/String;

    .line 101
    :cond_0
    const-string v1, "WeChatPay"

    const-string v2, "getProduct"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 104
    new-instance v1, Lcom/igg/sdk/service/IGGPaymentService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGPaymentService;-><init>()V

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->payInfo:Lcom/igg/sdk/service/IGGPaymentService;

    .line 127
    new-instance v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    const-string v2, "wechat"

    invoke-direct {v0, v1, v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 128
    .local v0, "loader":Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;
    new-instance v1, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;-><init>(Lcom/igg/iggsdkbusiness/ProuductWeChat;)V

    invoke-virtual {v0, v1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->loadItems(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;)V

    .line 147
    return-void
.end method

.method public getProduct(Ljava/lang/String;)V
    .locals 1
    .param p1, "iggid"    # Ljava/lang/String;

    .prologue
    .line 214
    if-eqz p1, :cond_0

    const-string v0, ""

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 221
    :cond_0
    :goto_0
    return-void

    .line 219
    :cond_1
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->IGGID:Ljava/lang/String;

    .line 220
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->getProduct()V

    goto :goto_0
.end method

.method public payCancelCallBack()V
    .locals 2

    .prologue
    .line 84
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat;->payCancelCallBack:Ljava/lang/String;

    const-string v1, "The Item you were attempting to purchase could not be found."

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 85
    return-void
.end method
