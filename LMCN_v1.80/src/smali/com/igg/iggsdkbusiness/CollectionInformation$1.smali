.class Lcom/igg/iggsdkbusiness/CollectionInformation$1;
.super Ljava/lang/Object;
.source "CollectionInformation.java"

# interfaces
.implements Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/CollectionInformation;->saveIncident(Lcom/igg/sdk/incident/IGGIncident;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/CollectionInformation;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/CollectionInformation;

    .prologue
    .line 60
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFinished(ZLjava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "success"    # Z
    .param p2, "code"    # Ljava/lang/String;
    .param p3, "description"    # Ljava/lang/String;

    .prologue
    .line 65
    if-nez p1, :cond_5

    .line 66
    const-string v0, "101"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 67
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/CollectionInformation;->setValueCallback:Ljava/lang/String;

    const-string v2, "\u6807\u9898\u4e0d\u80fd\u4e3a\u7a7a"

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/CollectionInformation;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 90
    :cond_0
    :goto_0
    return-void

    .line 69
    :cond_1
    const-string v0, "102"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 70
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/CollectionInformation;->setValueCallback:Ljava/lang/String;

    const-string v2, "\u63cf\u8ff0\u4e0d\u80fd\u4e3a\u7a7a"

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/CollectionInformation;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 72
    :cond_2
    const-string v0, "103"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_3

    .line 73
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/CollectionInformation;->setValueCallback:Ljava/lang/String;

    const-string v2, "\u7c7b\u578b\u4e0d\u80fd\u4e3a\u7a7a"

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/CollectionInformation;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 76
    :cond_3
    const-string v0, "105"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_4

    .line 77
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/CollectionInformation;->FailedCallBack:Ljava/lang/String;

    const-string v2, "\u51fa\u73b0\u5f02\u5e38\u9519\u8bef"

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/CollectionInformation;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 79
    :cond_4
    const-string v0, "106"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 80
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/CollectionInformation;->FailedCallBack:Ljava/lang/String;

    const-string v2, "\u7c7b\u578b\u4e0d\u80fd\u4e3a\u7a7a"

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/CollectionInformation;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 84
    :cond_5
    const-string v0, "0"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 85
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/CollectionInformation$1;->this$0:Lcom/igg/iggsdkbusiness/CollectionInformation;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/CollectionInformation;->SuccessfulCallBack:Ljava/lang/String;

    const-string v2, "\u7c7b\u578b\u4e0d\u80fd\u4e3a\u7a7a"

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/CollectionInformation;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
