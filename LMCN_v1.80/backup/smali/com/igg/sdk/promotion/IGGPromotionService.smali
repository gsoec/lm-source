.class public Lcom/igg/sdk/promotion/IGGPromotionService;
.super Ljava/lang/Object;
.source "IGGPromotionService.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/promotion/IGGPromotionService$InitilizationHandler;
    }
.end annotation


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGPromotionService"


# instance fields
.field private IGGId:Ljava/lang/String;

.field private adId:Ljava/lang/String;

.field private androidId:Ljava/lang/String;

.field private context:Landroid/content/Context;

.field private gameId:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "IGGId"    # Ljava/lang/String;

    .prologue
    .line 60
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 61
    iput-object p1, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->gameId:Ljava/lang/String;

    .line 62
    iput-object p2, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->IGGId:Ljava/lang/String;

    .line 63
    return-void
.end method

.method private APIforAction(Ljava/lang/String;)Ljava/lang/String;
    .locals 8
    .param p1, "action"    # Ljava/lang/String;

    .prologue
    .line 274
    :try_start_0
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "gid="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->gameId:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "&uid="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->IGGId:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "&aid="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->androidId:Ljava/lang/String;

    const-string v5, "utf-8"

    .line 275
    invoke-static {v4, v5}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "&adid="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->adId:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "&mac="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->context:Landroid/content/Context;

    .line 276
    invoke-static {v4}, Lcom/igg/util/DeviceUtil;->getLocalMacAddress(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v4

    const-string v5, "utf-8"

    invoke-static {v4, v5}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "&imei="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->context:Landroid/content/Context;

    .line 277
    invoke-static {v4}, Lcom/igg/util/DeviceUtil;->getIMEI(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v4

    const-string v5, "utf-8"

    invoke-static {v4, v5}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "&action="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "&platform=android"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 281
    .local v2, "parametersStr":Ljava/lang/String;
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getFamily()Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    move-result-object v3

    sget-object v4, Lcom/igg/sdk/IGGSDKConstant$IGGFamily;->FP:Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    if-ne v3, v4, :cond_0

    .line 282
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "app-promotion.fantasyplus.game.tw"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 287
    .local v0, "dnsUrl":Ljava/lang/String;
    :goto_0
    const-string v3, "%s?%s"

    const/4 v4, 0x2

    new-array v4, v4, [Ljava/lang/Object;

    const/4 v5, 0x0

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v6, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, "/app-install/client-api.php"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    aput-object v6, v4, v5

    const/4 v5, 0x1

    aput-object v2, v4, v5

    invoke-static {v3, v4}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    .line 290
    .end local v0    # "dnsUrl":Ljava/lang/String;
    .end local v2    # "parametersStr":Ljava/lang/String;
    :goto_1
    return-object v3

    .line 284
    .restart local v2    # "parametersStr":Ljava/lang/String;
    :cond_0
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "app-promotion.igg.com"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    .restart local v0    # "dnsUrl":Ljava/lang/String;
    goto :goto_0

    .line 288
    .end local v0    # "dnsUrl":Ljava/lang/String;
    .end local v2    # "parametersStr":Ljava/lang/String;
    :catch_0
    move-exception v1

    .line 289
    .local v1, "e":Ljava/io/UnsupportedEncodingException;
    invoke-virtual {v1}, Ljava/io/UnsupportedEncodingException;->printStackTrace()V

    .line 290
    const/4 v3, 0x0

    goto :goto_1
.end method

.method static synthetic access$102(Lcom/igg/sdk/promotion/IGGPromotionService;Ljava/lang/String;)Ljava/lang/String;
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/promotion/IGGPromotionService;
    .param p1, "x1"    # Ljava/lang/String;

    .prologue
    .line 40
    iput-object p1, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->adId:Ljava/lang/String;

    return-object p1
.end method


# virtual methods
.method public initialize(Landroid/content/Context;Lcom/igg/sdk/promotion/listener/IGGInitializationListener;)V
    .locals 4
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "listener"    # Lcom/igg/sdk/promotion/listener/IGGInitializationListener;

    .prologue
    .line 71
    iput-object p1, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->context:Landroid/content/Context;

    .line 74
    :try_start_0
    invoke-virtual {p1}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object v2

    const-string v3, "android_id"

    invoke-static {v2, v3}, Landroid/provider/Settings$Secure;->getString(Landroid/content/ContentResolver;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    iput-object v2, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->androidId:Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 82
    :goto_0
    new-instance v1, Lcom/igg/sdk/promotion/IGGPromotionService$1;

    invoke-direct {v1, p0, p2}, Lcom/igg/sdk/promotion/IGGPromotionService$1;-><init>(Lcom/igg/sdk/promotion/IGGPromotionService;Lcom/igg/sdk/promotion/listener/IGGInitializationListener;)V

    .line 93
    .local v1, "handler":Landroid/os/Handler;
    new-instance v2, Ljava/lang/Thread;

    new-instance v3, Lcom/igg/sdk/promotion/IGGPromotionService$2;

    invoke-direct {v3, p0, p1, v1}, Lcom/igg/sdk/promotion/IGGPromotionService$2;-><init>(Lcom/igg/sdk/promotion/IGGPromotionService;Landroid/content/Context;Landroid/os/Handler;)V

    invoke-direct {v2, v3}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    .line 122
    invoke-virtual {v2}, Ljava/lang/Thread;->start()V

    .line 123
    return-void

    .line 75
    .end local v1    # "handler":Landroid/os/Handler;
    :catch_0
    move-exception v0

    .line 76
    .local v0, "e":Ljava/lang/Exception;
    const-string v2, ""

    iput-object v2, p0, Lcom/igg/sdk/promotion/IGGPromotionService;->androidId:Ljava/lang/String;

    .line 78
    const-string v2, "IGGPromotionService"

    const-string v3, "Failed to get androidId"

    invoke-static {v2, v3}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 79
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method public loadShowcase(Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;)V
    .locals 4
    .param p1, "listener"    # Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;

    .prologue
    .line 131
    new-instance v0, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    const-string v1, "fetch-promotion"

    invoke-direct {p0, v1}, Lcom/igg/sdk/promotion/IGGPromotionService;->APIforAction(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const/4 v2, 0x0

    new-instance v3, Lcom/igg/sdk/promotion/IGGPromotionService$3;

    invoke-direct {v3, p0, p1}, Lcom/igg/sdk/promotion/IGGPromotionService$3;-><init>(Lcom/igg/sdk/promotion/IGGPromotionService;Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;)V

    invoke-virtual {v0, v1, v2, v3}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 184
    return-void
.end method

.method public onDismiss(Lcom/igg/sdk/promotion/model/IGGShowcase;Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;)V
    .locals 4
    .param p1, "showcase"    # Lcom/igg/sdk/promotion/model/IGGShowcase;
    .param p2, "listener"    # Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    .prologue
    .line 193
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 194
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "id"

    invoke-virtual {p1}, Lcom/igg/sdk/promotion/model/IGGShowcase;->getId()I

    move-result v2

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 196
    new-instance v1, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGService;-><init>()V

    const-string v2, "close"

    invoke-direct {p0, v2}, Lcom/igg/sdk/promotion/IGGPromotionService;->APIforAction(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/promotion/IGGPromotionService$4;

    invoke-direct {v3, p0, p2}, Lcom/igg/sdk/promotion/IGGPromotionService$4;-><init>(Lcom/igg/sdk/promotion/IGGPromotionService;Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;)V

    invoke-virtual {v1, v2, v0, v3}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 227
    return-void
.end method

.method public onDismissForever(Lcom/igg/sdk/promotion/model/IGGShowcase;Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;)V
    .locals 4
    .param p1, "showcase"    # Lcom/igg/sdk/promotion/model/IGGShowcase;
    .param p2, "listener"    # Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    .prologue
    .line 236
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 237
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "id"

    invoke-virtual {p1}, Lcom/igg/sdk/promotion/model/IGGShowcase;->getId()I

    move-result v2

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 239
    new-instance v1, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGService;-><init>()V

    const-string v2, "ignore"

    invoke-direct {p0, v2}, Lcom/igg/sdk/promotion/IGGPromotionService;->APIforAction(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/promotion/IGGPromotionService$5;

    invoke-direct {v3, p0, p2}, Lcom/igg/sdk/promotion/IGGPromotionService$5;-><init>(Lcom/igg/sdk/promotion/IGGPromotionService;Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;)V

    invoke-virtual {v1, v2, v0, v3}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 270
    return-void
.end method
