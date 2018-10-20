.class public Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;
.super Ljava/lang/Object;
.source "IGGPaymentCacheLoadingManager.java"


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGPaymentCacheLoadingManager"

.field private static instance:Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;


# instance fields
.field private cacheComplexItems:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;"
        }
    .end annotation
.end field

.field private cacheItems:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method private constructor <init>()V
    .locals 0

    .prologue
    .line 26
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 28
    return-void
.end method

.method static synthetic access$002(Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;Ljava/util/List;)Ljava/util/List;
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;
    .param p1, "x1"    # Ljava/util/List;

    .prologue
    .line 18
    iput-object p1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheComplexItems:Ljava/util/List;

    return-object p1
.end method

.method static synthetic access$100(Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;)Ljava/util/ArrayList;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    .prologue
    .line 18
    iget-object v0, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheItems:Ljava/util/ArrayList;

    return-object v0
.end method

.method public static declared-synchronized sharedInstance()Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;
    .locals 2

    .prologue
    .line 31
    const-class v1, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->instance:Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    if-nez v0, :cond_0

    .line 32
    new-instance v0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    invoke-direct {v0}, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;-><init>()V

    sput-object v0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->instance:Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    .line 35
    :cond_0
    sget-object v0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->instance:Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit v1

    return-object v0

    .line 31
    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method


# virtual methods
.method public invalidateComplexItemsCache()V
    .locals 1

    .prologue
    .line 73
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheComplexItems:Ljava/util/List;

    .line 74
    return-void
.end method

.method public loadCache(ZLcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;)V
    .locals 3
    .param p1, "isGetGooglePlayPrice"    # Z
    .param p2, "listener"    # Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;

    .prologue
    .line 39
    iget-object v1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheItems:Ljava/util/ArrayList;

    if-eqz v1, :cond_0

    iget-object v1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheItems:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v1

    if-nez v1, :cond_1

    .line 64
    :cond_0
    :goto_0
    return-void

    .line 43
    :cond_1
    if-eqz p1, :cond_4

    .line 44
    iget-object v1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheComplexItems:Ljava/util/List;

    if-eqz v1, :cond_2

    iget-object v1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheComplexItems:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    if-nez v1, :cond_3

    .line 45
    :cond_2
    new-instance v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;

    invoke-direct {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;-><init>()V

    .line 46
    .local v0, "composer":Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;
    iget-object v1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheItems:Ljava/util/ArrayList;

    new-instance v2, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager$1;

    invoke-direct {v2, p0, p2}, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager$1;-><init>(Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;)V

    invoke-virtual {v0, v1, v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;->compose(Ljava/util/ArrayList;Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;)V

    goto :goto_0

    .line 59
    .end local v0    # "composer":Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;
    :cond_3
    iget-object v1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheComplexItems:Ljava/util/List;

    invoke-interface {p2, v1}, Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;->onLoadCacheFinished(Ljava/util/List;)V

    goto :goto_0

    .line 62
    :cond_4
    iget-object v1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheItems:Ljava/util/ArrayList;

    invoke-interface {p2, v1}, Lcom/igg/sdk/payment/google/cache/IGGPaymentLoadCacheListener;->onLoadCacheFinished(Ljava/util/List;)V

    goto :goto_0
.end method

.method public saveCache(Ljava/util/ArrayList;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 67
    .local p1, "items":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    if-eqz p1, :cond_0

    invoke-virtual {p1}, Ljava/util/ArrayList;->size()I

    move-result v0

    if-lez v0, :cond_0

    .line 68
    iput-object p1, p0, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->cacheItems:Ljava/util/ArrayList;

    .line 70
    :cond_0
    return-void
.end method
