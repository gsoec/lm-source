.class Lcom/igg/sdk/IGGSDK$1$1;
.super Ljava/lang/Object;
.source "IGGSDK.java"

# interfaces
.implements Lcom/igg/util/DeviceUtil$getAdvertisingIdListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/IGGSDK$1;->onResult(Z)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/sdk/IGGSDK$1;

.field final synthetic val$androidId:Ljava/lang/String;

.field final synthetic val$macAdress:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/IGGSDK$1;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/sdk/IGGSDK$1;

    .prologue
    .line 531
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK$1$1;->this$1:Lcom/igg/sdk/IGGSDK$1;

    iput-object p2, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$macAdress:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$androidId:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onRequestFinished(Ljava/lang/String;)V
    .locals 4
    .param p1, "advertisingId"    # Ljava/lang/String;

    .prologue
    .line 534
    if-eqz p1, :cond_0

    const-string v1, ""

    invoke-virtual {p1, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 535
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "gaid="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ",mac="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$macAdress:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ",aid="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$androidId:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 536
    .local v0, "str":Ljava/lang/String;
    const-string v1, "IGGSDK"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Not Emulator-gaid="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 537
    iget-object v1, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$macAdress:Ljava/lang/String;

    if-eqz v1, :cond_2

    iget-object v1, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$macAdress:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    iget-object v1, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$macAdress:Ljava/lang/String;

    invoke-static {v1}, Lcom/igg/util/FilterMacAddress;->isInvalidMacAdress(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_2

    .line 538
    iget-object v1, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$androidId:Ljava/lang/String;

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$androidId:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_1

    .line 539
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "gaid="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ",mac="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$macAdress:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ",aid="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$androidId:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 551
    :goto_0
    iget-object v1, p0, Lcom/igg/sdk/IGGSDK$1$1;->this$1:Lcom/igg/sdk/IGGSDK$1;

    iget-object v1, v1, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-virtual {v1, v0}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 552
    iget-object v1, p0, Lcom/igg/sdk/IGGSDK$1$1;->this$1:Lcom/igg/sdk/IGGSDK$1;

    iget-object v1, v1, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    invoke-virtual {v1, v0}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 554
    .end local v0    # "str":Ljava/lang/String;
    :cond_0
    return-void

    .line 541
    .restart local v0    # "str":Ljava/lang/String;
    :cond_1
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "gaid="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ",mac="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$macAdress:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    goto :goto_0

    .line 544
    :cond_2
    iget-object v1, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$androidId:Ljava/lang/String;

    if-eqz v1, :cond_3

    iget-object v1, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$androidId:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_3

    iget-object v1, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$androidId:Ljava/lang/String;

    invoke-static {v1}, Lcom/igg/util/FilterAndroidId;->isInvalidAndroidId(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_3

    .line 545
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "gaid="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ",aid="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/IGGSDK$1$1;->val$androidId:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    goto :goto_0

    .line 547
    :cond_3
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "gaid="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    goto :goto_0
.end method
