.class Lcom/igg/iggsdkbusiness/IGGAdwordsHelper$1;
.super Ljava/lang/Object;
.source "IGGAdwordsHelper.java"

# interfaces
.implements Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->Install()V
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
    .line 75
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper$1;->this$0:Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFinished(Lcom/igg/sdk/error/IGGException;)V
    .locals 5
    .param p1, "exception"    # Lcom/igg/sdk/error/IGGException;

    .prologue
    .line 78
    const-string v0, "IGGAdwordsHelper"

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGException;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 79
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGException;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 80
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper$1;->this$0:Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    invoke-static {v0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->access$000(Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;)Landroid/app/Activity;

    move-result-object v0

    const-string v1, "844484708"

    const-string v2, "C2bJCK-Mr3UQ5KDXkgM"

    const-string v3, "0.00"

    const/4 v4, 0x0

    invoke-static {v0, v1, v2, v3, v4}, Lcom/google/ads/conversiontracking/AdWordsConversionReporter;->reportWithConversionId(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Z)V

    .line 85
    :goto_0
    return-void

    .line 84
    :cond_0
    const-string v0, "IGGAdwordsHelper"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "isNone = false_ getCode = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGException;->getCode()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method
