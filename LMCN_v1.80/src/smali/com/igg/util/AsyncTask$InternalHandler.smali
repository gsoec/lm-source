.class Lcom/igg/util/AsyncTask$InternalHandler;
.super Landroid/os/Handler;
.source "AsyncTask.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/util/AsyncTask;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0xa
    name = "InternalHandler"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .prologue
    .line 662
    invoke-direct {p0}, Landroid/os/Handler;-><init>()V

    return-void
.end method

.method synthetic constructor <init>(Lcom/igg/util/AsyncTask$1;)V
    .locals 0
    .param p1, "x0"    # Lcom/igg/util/AsyncTask$1;

    .prologue
    .line 662
    invoke-direct {p0}, Lcom/igg/util/AsyncTask$InternalHandler;-><init>()V

    return-void
.end method


# virtual methods
.method public handleMessage(Landroid/os/Message;)V
    .locals 4
    .param p1, "msg"    # Landroid/os/Message;

    .prologue
    .line 666
    iget-object v0, p1, Landroid/os/Message;->obj:Ljava/lang/Object;

    check-cast v0, Lcom/igg/util/AsyncTask$AsyncTaskResult;

    .line 667
    .local v0, "result":Lcom/igg/util/AsyncTask$AsyncTaskResult;
    iget v1, p1, Landroid/os/Message;->what:I

    packed-switch v1, :pswitch_data_0

    .line 676
    :goto_0
    return-void

    .line 670
    :pswitch_0
    iget-object v1, v0, Lcom/igg/util/AsyncTask$AsyncTaskResult;->mTask:Lcom/igg/util/AsyncTask;

    iget-object v2, v0, Lcom/igg/util/AsyncTask$AsyncTaskResult;->mData:[Ljava/lang/Object;

    const/4 v3, 0x0

    aget-object v2, v2, v3

    invoke-static {v1, v2}, Lcom/igg/util/AsyncTask;->access$600(Lcom/igg/util/AsyncTask;Ljava/lang/Object;)V

    goto :goto_0

    .line 673
    :pswitch_1
    iget-object v1, v0, Lcom/igg/util/AsyncTask$AsyncTaskResult;->mTask:Lcom/igg/util/AsyncTask;

    iget-object v2, v0, Lcom/igg/util/AsyncTask$AsyncTaskResult;->mData:[Ljava/lang/Object;

    invoke-virtual {v1, v2}, Lcom/igg/util/AsyncTask;->onProgressUpdate([Ljava/lang/Object;)V

    goto :goto_0

    .line 667
    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
    .end packed-switch
.end method
