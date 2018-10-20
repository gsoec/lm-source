.class public Lcom/igg/sdk/service/IGGPaymentService;
.super Lcom/igg/sdk/service/IGGService;
.source "IGGPaymentService.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;,
        Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;,
        Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;,
        Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;,
        Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;,
        Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;
    }
.end annotation


# static fields
.field protected static TAG:Ljava/lang/String;


# instance fields
.field private channelName:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 29
    const-string v0, "IGGPaymentService"

    sput-object v0, Lcom/igg/sdk/service/IGGPaymentService;->TAG:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 28
    invoke-direct {p0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    return-void
.end method


# virtual methods
.method public getAlipayOrder(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;)V
    .locals 5
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "itemId"    # Ljava/lang/String;
    .param p3, "subject"    # Ljava/lang/String;
    .param p4, "price"    # Ljava/lang/String;
    .param p5, "quantity"    # Ljava/lang/String;
    .param p6, "orderInfo"    # Ljava/lang/String;
    .param p7, "listener"    # Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;

    .prologue
    .line 350
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v1

    .line 351
    .local v1, "gameId":Ljava/lang/String;
    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getAlipayAPI()Ljava/lang/String;

    move-result-object v0

    .line 352
    .local v0, "URL":Ljava/lang/String;
    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    .line 353
    .local v2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v3, "gid"

    invoke-virtual {v2, v3, v1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 354
    const-string v3, "iggid"

    invoke-virtual {v2, v3, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 355
    const-string v3, "itemId"

    invoke-virtual {v2, v3, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 356
    const-string v3, "itemName"

    invoke-virtual {v2, v3, p3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 357
    const-string v3, "unitPrice"

    invoke-virtual {v2, v3, p4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 358
    const-string v3, "quantity"

    invoke-virtual {v2, v3, p5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 359
    const-string v3, "orderInfo"

    invoke-virtual {v2, v3, p6}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 360
    new-instance v3, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v3}, Lcom/igg/sdk/service/IGGService;-><init>()V

    new-instance v4, Lcom/igg/sdk/service/IGGPaymentService$7;

    invoke-direct {v4, p0, p7}, Lcom/igg/sdk/service/IGGPaymentService$7;-><init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;)V

    invoke-virtual {v3, v0, v2, v4}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 404
    return-void
.end method

.method public getBlueOrdersSerialNumber(Ljava/lang/String;ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;)V
    .locals 3
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "itemId"    # I
    .param p3, "amount"    # Ljava/lang/String;
    .param p4, "currency"    # Ljava/lang/String;
    .param p5, "chaId"    # Ljava/lang/String;
    .param p6, "serverId"    # Ljava/lang/String;
    .param p7, "listener"    # Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;

    .prologue
    .line 261
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v2, p0, Lcom/igg/sdk/service/IGGPaymentService;->channelName:Ljava/lang/String;

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getProductOrderNumberAPI(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "?u_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&g_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&item_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&amount="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&currency="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&cha_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&server_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 264
    .local v0, "URL":Ljava/lang/String;
    const/4 v1, 0x0

    new-instance v2, Lcom/igg/sdk/service/IGGPaymentService$5;

    invoke-direct {v2, p0, p7}, Lcom/igg/sdk/service/IGGPaymentService$5;-><init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;)V

    invoke-super {p0, v0, v1, v2}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 288
    return-void
.end method

.method public getOrdersSerialNumber(Ljava/lang/String;IILjava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;)V
    .locals 4
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "itemId"    # I
    .param p3, "amount"    # I
    .param p4, "chaId"    # Ljava/lang/String;
    .param p5, "serverId"    # Ljava/lang/String;
    .param p6, "listener"    # Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;

    .prologue
    .line 218
    sget-object v1, Lcom/igg/sdk/service/IGGPaymentService;->TAG:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "channelName"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    iget-object v3, p0, Lcom/igg/sdk/service/IGGPaymentService;->channelName:Ljava/lang/String;

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 219
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v2, p0, Lcom/igg/sdk/service/IGGPaymentService;->channelName:Ljava/lang/String;

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getProductOrderNumberAPI(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "?u_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&g_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&item_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&amount="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&cha_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&server_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 222
    .local v0, "URL":Ljava/lang/String;
    const/4 v1, 0x0

    new-instance v2, Lcom/igg/sdk/service/IGGPaymentService$4;

    invoke-direct {v2, p0, p6}, Lcom/igg/sdk/service/IGGPaymentService$4;-><init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;)V

    invoke-super {p0, v0, v1, v2}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 247
    return-void
.end method

.method public getWeChatOrder(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V
    .locals 4
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "itemId"    # Ljava/lang/String;
    .param p3, "itemName"    # Ljava/lang/String;
    .param p4, "price"    # Ljava/lang/String;
    .param p5, "quantity"    # Ljava/lang/String;
    .param p6, "listener"    # Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;

    .prologue
    .line 301
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v1

    .line 302
    .local v1, "gameId":Ljava/lang/String;
    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getWeiXinPayAPI()Ljava/lang/String;

    move-result-object v0

    .line 303
    .local v0, "URL":Ljava/lang/String;
    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    .line 304
    .local v2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v3, "gid"

    invoke-virtual {v2, v3, v1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 305
    const-string v3, "iggid"

    invoke-virtual {v2, v3, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 306
    const-string v3, "itemId"

    invoke-virtual {v2, v3, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 307
    const-string v3, "itemName"

    invoke-virtual {v2, v3, p3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 308
    const-string v3, "unitPrice"

    invoke-virtual {v2, v3, p4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 309
    const-string v3, "quantity"

    invoke-virtual {v2, v3, p5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 310
    new-instance v3, Lcom/igg/sdk/service/IGGPaymentService$6;

    invoke-direct {v3, p0, p6}, Lcom/igg/sdk/service/IGGPaymentService$6;-><init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V

    invoke-super {p0, v0, v2, v3}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 336
    return-void
.end method

.method public loadItems(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;)V
    .locals 7
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "channelName"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;

    .prologue
    .line 153
    iput-object p2, p0, Lcom/igg/sdk/service/IGGPaymentService;->channelName:Ljava/lang/String;

    .line 155
    const/16 v3, 0x3a98

    .line 156
    .local v3, "connectTimeOut":I
    const/16 v4, 0x3a98

    .line 157
    .local v4, "readTimeOut":I
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getProductAPI()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "?m_id="

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "&g_id="

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "&p_name="

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "&limitcheck=1&version=2"

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 158
    .local v1, "URL":Ljava/lang/String;
    const-string v0, "android"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    const-string v0, "amazonmobile"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 159
    :cond_0
    const/16 v3, 0xfa0

    .line 160
    const/16 v4, 0x1770

    .line 163
    :cond_1
    const/4 v2, 0x0

    new-instance v5, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v0

    invoke-direct {v5, v0}, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;-><init>(Landroid/content/Context;)V

    new-instance v6, Lcom/igg/sdk/service/IGGPaymentService$2;

    invoke-direct {v6, p0, p3}, Lcom/igg/sdk/service/IGGPaymentService$2;-><init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;)V

    move-object v0, p0

    invoke-super/range {v0 .. v6}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;IILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 178
    return-void
.end method

.method public loadItemsList(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;)V
    .locals 2
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "channelName"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;

    .prologue
    .line 181
    iput-object p2, p0, Lcom/igg/sdk/service/IGGPaymentService;->channelName:Ljava/lang/String;

    .line 182
    new-instance v0, Lcom/igg/sdk/service/IGGPaymentService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGPaymentService;-><init>()V

    new-instance v1, Lcom/igg/sdk/service/IGGPaymentService$3;

    invoke-direct {v1, p0, p3}, Lcom/igg/sdk/service/IGGPaymentService$3;-><init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;)V

    invoke-virtual {v0, p1, p2, v1}, Lcom/igg/sdk/service/IGGPaymentService;->loadItems(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;)V

    .line 207
    return-void
.end method

.method public requestLimitState(Ljava/lang/String;Ljava/lang/String;IIFZLcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;)V
    .locals 7
    .param p1, "iggId"    # Ljava/lang/String;
    .param p2, "gameId"    # Ljava/lang/String;
    .param p3, "pcId"    # I
    .param p4, "isEnableAntiAddiction"    # I
    .param p5, "antiAddictionPCQ"    # F
    .param p6, "isUseStandby"    # Z
    .param p7, "listener"    # Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;

    .prologue
    .line 69
    const/16 v3, 0x1388

    .line 70
    .local v3, "connectTimeOut":I
    const/16 v4, 0x1388

    .line 71
    .local v4, "readTimeOut":I
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    if-eqz p6, :cond_0

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getStandbyPaymentLimitStateAPI()Ljava/lang/String;

    move-result-object v0

    :goto_0
    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "?m_id="

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "&g_id="

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "&pc_id="

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "&anti_addiction_enabled="

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "&anti_addiction_pcq="

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p5}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 74
    .local v1, "url":Ljava/lang/String;
    const/4 v2, 0x0

    new-instance v5, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v0

    invoke-direct {v5, v0}, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;-><init>(Landroid/content/Context;)V

    new-instance v6, Lcom/igg/sdk/service/IGGPaymentService$1;

    invoke-direct {v6, p0, p7}, Lcom/igg/sdk/service/IGGPaymentService$1;-><init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;)V

    move-object v0, p0

    invoke-super/range {v0 .. v6}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;IILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 143
    return-void

    .line 71
    .end local v1    # "url":Ljava/lang/String;
    :cond_0
    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getPaymentLimitStateAPI()Ljava/lang/String;

    move-result-object v0

    goto :goto_0
.end method
