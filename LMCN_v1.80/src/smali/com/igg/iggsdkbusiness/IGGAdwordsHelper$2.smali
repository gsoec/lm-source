.class Lcom/igg/iggsdkbusiness/IGGAdwordsHelper$2;
.super Ljava/lang/Object;
.source "IGGAdwordsHelper.java"

# interfaces
.implements Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->SingUp()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    .prologue
    .line 102
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper$2;->this$0:Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFinished(Lcom/igg/sdk/error/IGGException;)V
    .locals 1
    .param p1, "exception"    # Lcom/igg/sdk/error/IGGException;

    .prologue
    .line 105
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGException;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 111
    :cond_0
    return-void
.end method
