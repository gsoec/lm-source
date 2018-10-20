.class public Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;
.super Ljava/lang/Object;
.source "IGGPaymentItemsLoadingManager.java"


# instance fields
.field private cardsLoader:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

.field private channelName:Ljava/lang/String;

.field private count:I

.field private isGetGooglePlayPrice:Z

.field private isInterrupted:Ljava/util/concurrent/atomic/AtomicBoolean;

.field private isLoading:Ljava/util/concurrent/atomic/AtomicBoolean;

.field private listener:Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

.field private loadHandler:Landroid/os/Handler;

.field private loadedCards:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;


# direct methods
.method public constructor <init>(Ljava/lang/String;Z)V
    .locals 2
    .param p1, "channelName"    # Ljava/lang/String;
    .param p2, "isGetGooglePlayPrice"    # Z

    .prologue
    const/4 v1, 0x0

    .line 39
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 33
    iput v1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->count:I

    .line 34
    new-instance v0, Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-direct {v0, v1}, Ljava/util/concurrent/atomic/AtomicBoolean;-><init>(Z)V

    iput-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isLoading:Ljava/util/concurrent/atomic/AtomicBoolean;

    .line 35
    new-instance v0, Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-direct {v0, v1}, Ljava/util/concurrent/atomic/AtomicBoolean;-><init>(Z)V

    iput-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isInterrupted:Ljava/util/concurrent/atomic/AtomicBoolean;

    .line 37
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    iput-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadHandler:Landroid/os/Handler;

    .line 40
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->channelName:Ljava/lang/String;

    .line 41
    iput-boolean p2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isGetGooglePlayPrice:Z

    .line 42
    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 25
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadedCards:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    return-object v0
.end method

.method static synthetic access$002(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;)Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;
    .param p1, "x1"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    .prologue
    .line 25
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadedCards:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    return-object p1
.end method

.method static synthetic access$100(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 25
    invoke-direct {p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->composeIfNeed()V

    return-void
.end method

.method static synthetic access$200(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)I
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 25
    iget v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->count:I

    return v0
.end method

.method static synthetic access$300(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Z
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 25
    iget-boolean v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isGetGooglePlayPrice:Z

    return v0
.end method

.method static synthetic access$400(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 25
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->listener:Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    return-object v0
.end method

.method static synthetic access$500(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Z
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 25
    invoke-direct {p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->retryLoad()Z

    move-result v0

    return v0
.end method

.method static synthetic access$600(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;
    .param p1, "x1"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "x2"    # Ljava/util/List;

    .prologue
    .line 25
    invoke-direct {p0, p1, p2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->onLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    return-void
.end method

.method static synthetic access$700(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 25
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->cardsLoader:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    return-object v0
.end method

.method static synthetic access$800(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)Ljava/util/concurrent/atomic/AtomicBoolean;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 25
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isInterrupted:Ljava/util/concurrent/atomic/AtomicBoolean;

    return-object v0
.end method

.method static synthetic access$900(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;

    .prologue
    .line 25
    invoke-direct {p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadItemsInternal()V

    return-void
.end method

.method private cancelListener()V
    .locals 1

    .prologue
    .line 196
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->listener:Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    if-eqz v0, :cond_0

    .line 197
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->listener:Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    .line 199
    :cond_0
    return-void
.end method

.method private clearLoader()V
    .locals 1

    .prologue
    .line 190
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->cardsLoader:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    if-eqz v0, :cond_0

    .line 191
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->cardsLoader:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    .line 193
    :cond_0
    return-void
.end method

.method private composeIfNeed()V
    .locals 3

    .prologue
    .line 117
    iget-object v1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->listener:Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    if-eqz v1, :cond_0

    .line 118
    iget-boolean v1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isGetGooglePlayPrice:Z

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadedCards:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    invoke-virtual {v1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->getIGGGameItems()Ljava/util/ArrayList;

    move-result-object v1

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v1

    if-lez v1, :cond_1

    .line 119
    new-instance v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;

    invoke-direct {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;-><init>()V

    .line 120
    .local v0, "composer":Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;
    const-string v1, "ItemsLoadingManager"

    const-string v2, "compose"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 121
    iget-object v1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadedCards:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    invoke-virtual {v1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->getIGGGameItems()Ljava/util/ArrayList;

    move-result-object v1

    new-instance v2, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$2;

    invoke-direct {v2, p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$2;-><init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)V

    invoke-virtual {v0, v1, v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;->compose(Ljava/util/ArrayList;Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer$IGGPaymentCardsComposedListener;)V

    .line 138
    .end local v0    # "composer":Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsComposer;
    :cond_0
    :goto_0
    return-void

    .line 135
    :cond_1
    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadedCards:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    invoke-virtual {v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->getIGGGameItems()Ljava/util/ArrayList;

    move-result-object v2

    invoke-direct {p0, v1, v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->onLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    goto :goto_0
.end method

.method private handleFinish()V
    .locals 2

    .prologue
    const/4 v1, 0x0

    .line 181
    invoke-direct {p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->clearLoader()V

    .line 182
    invoke-direct {p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->cancelListener()V

    .line 183
    iput v1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->count:I

    .line 184
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadedCards:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    .line 185
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isLoading:Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-virtual {v0, v1}, Ljava/util/concurrent/atomic/AtomicBoolean;->set(Z)V

    .line 186
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isInterrupted:Ljava/util/concurrent/atomic/AtomicBoolean;

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Ljava/util/concurrent/atomic/AtomicBoolean;->set(Z)V

    .line 187
    return-void
.end method

.method private loadItemsInternal()V
    .locals 2

    .prologue
    .line 75
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadHandler:Landroid/os/Handler;

    new-instance v1, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;

    invoke-direct {v1, p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$1;-><init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;)V

    invoke-virtual {v0, v1}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 114
    return-void
.end method

.method private onLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
    .locals 1
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 170
    .local p2, "items":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 171
    invoke-static {}, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->sharedInstance()Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/payment/google/cache/IGGPaymentCacheLoadingManager;->invalidateComplexItemsCache()V

    .line 174
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->listener:Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    if-eqz v0, :cond_1

    .line 175
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->listener:Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    invoke-interface {v0, p1, p2}, Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;->onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    .line 177
    :cond_1
    invoke-direct {p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->handleFinish()V

    .line 178
    return-void
.end method

.method private retryLoad()Z
    .locals 4

    .prologue
    .line 141
    iget v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->count:I

    add-int/lit8 v2, v2, 0x1

    iput v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->count:I

    .line 143
    iget v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->count:I

    const/16 v3, 0xa

    if-ne v2, v3, :cond_0

    .line 144
    const/4 v2, 0x0

    .line 165
    :goto_0
    return v2

    .line 147
    :cond_0
    new-instance v1, Ljava/util/Timer;

    invoke-direct {v1}, Ljava/util/Timer;-><init>()V

    .line 148
    .local v1, "timer":Ljava/util/Timer;
    new-instance v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$3;

    invoke-direct {v0, p0, v1}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager$3;-><init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;Ljava/util/Timer;)V

    .line 159
    .local v0, "task":Ljava/util/TimerTask;
    iget v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->count:I

    const/4 v3, 0x3

    if-ge v2, v3, :cond_1

    .line 160
    const-wide/16 v2, 0xbb8

    invoke-virtual {v1, v0, v2, v3}, Ljava/util/Timer;->schedule(Ljava/util/TimerTask;J)V

    .line 165
    :goto_1
    const/4 v2, 0x1

    goto :goto_0

    .line 162
    :cond_1
    const-wide/16 v2, 0x4e20

    invoke-virtual {v1, v0, v2, v3}, Ljava/util/Timer;->schedule(Ljava/util/TimerTask;J)V

    goto :goto_1
.end method


# virtual methods
.method public destroy()V
    .locals 0

    .prologue
    .line 59
    invoke-direct {p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->handleFinish()V

    .line 60
    return-void
.end method

.method public getPurchaseLimit()I
    .locals 1

    .prologue
    .line 63
    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadedCards:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadedCards:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    invoke-virtual {v0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->getPurchaseLimit()I

    move-result v0

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public loadItems(Ljava/lang/String;Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;)Z
    .locals 3
    .param p1, "IGGId"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    .prologue
    const/4 v1, 0x1

    const/4 v0, 0x0

    .line 45
    iget-object v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isLoading:Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicBoolean;->get()Z

    move-result v2

    if-eqz v2, :cond_0

    .line 55
    :goto_0
    return v0

    .line 49
    :cond_0
    iget-object v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isLoading:Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-virtual {v2, v1}, Ljava/util/concurrent/atomic/AtomicBoolean;->set(Z)V

    .line 50
    iget-object v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isInterrupted:Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-virtual {v2, v0}, Ljava/util/concurrent/atomic/AtomicBoolean;->set(Z)V

    .line 52
    iput-object p2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->listener:Lcom/igg/sdk/payment/google/IGGPayment$PaymentItemsListener;

    .line 53
    new-instance v0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    iget-object v2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->channelName:Ljava/lang/String;

    invoke-direct {v0, p1, v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->cardsLoader:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    .line 54
    invoke-direct {p0}, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->loadItemsInternal()V

    move v0, v1

    .line 55
    goto :goto_0
.end method

.method public setChannelName(Ljava/lang/String;)V
    .locals 0
    .param p1, "channelName"    # Ljava/lang/String;

    .prologue
    .line 67
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->channelName:Ljava/lang/String;

    .line 68
    return-void
.end method

.method public setGetGooglePlayPrice(Z)V
    .locals 0
    .param p1, "getGooglePlayPrice"    # Z

    .prologue
    .line 71
    iput-boolean p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentItemsLoadingManager;->isGetGooglePlayPrice:Z

    .line 72
    return-void
.end method
