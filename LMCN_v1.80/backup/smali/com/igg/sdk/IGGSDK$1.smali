.class Lcom/igg/sdk/IGGSDK$1;
.super Ljava/lang/Object;
.source "IGGSDK.java"

# interfaces
.implements Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/IGGSDK;->detectDeviceRegisterId(Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/IGGSDK;

.field final synthetic val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

.field final synthetic val$listener:Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/IGGSDK;Lcom/igg/sdk/IGGDeviceStorage;Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/IGGSDK;

    .prologue
    .line 475
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    iput-object p2, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    iput-object p3, p0, Lcom/igg/sdk/IGGSDK$1;->val$listener:Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onResult(Z)V
    .locals 13
    .param p1, "isEmulator"    # Z

    .prologue
    .line 478
    const-string v10, "IGGSDK"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "isEmulator:"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, p1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 479
    if-eqz p1, :cond_1

    .line 481
    const-string v10, "IGGSDK"

    const-string v11, "Emulator-uuid as deviceid"

    invoke-static {v10, v11}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 483
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v10

    invoke-virtual {v10}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v10

    invoke-static {v10}, Lcom/igg/util/UUIDUtil;->getUUID(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v9

    .line 484
    .local v9, "uuid":Ljava/lang/String;
    if-eqz v9, :cond_0

    .line 485
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "uuid="

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 486
    const-string v10, "IGGSDK"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "Emulator-uuid="

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 487
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    const/4 v11, 0x1

    invoke-virtual {v10, v11}, Lcom/igg/sdk/IGGDeviceStorage;->setEmulatorFlag(Z)V

    .line 488
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$listener:Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;

    invoke-interface {v10}, Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;->finish()V

    .line 614
    :cond_0
    :goto_0
    return-void

    .line 493
    .end local v9    # "uuid":Ljava/lang/String;
    :cond_1
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v10

    invoke-virtual {v10}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v10

    invoke-static {v10}, Lcom/igg/util/UUIDUtil;->getSDUUID(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v9

    .line 495
    .restart local v9    # "uuid":Ljava/lang/String;
    if-eqz v9, :cond_0

    .line 496
    const-string v10, ""

    invoke-virtual {v9, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_2

    .line 498
    const-string v10, "IGGSDK"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "Not Emulator-uuid="

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 499
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "uuid="

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 500
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "uuid="

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 501
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$listener:Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;

    invoke-interface {v10}, Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;->finish()V

    goto :goto_0

    .line 506
    :cond_2
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-virtual {v10}, Lcom/igg/sdk/IGGDeviceStorage;->currentDeviceUID()Ljava/lang/String;

    move-result-object v7

    .line 507
    .local v7, "oldDeviceUID":Ljava/lang/String;
    const-string v10, ""

    invoke-virtual {v7, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-eqz v10, :cond_7

    .line 508
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    invoke-static {v10}, Lcom/igg/sdk/IGGSDK;->access$000(Lcom/igg/sdk/IGGSDK;)Landroid/app/Application;

    move-result-object v10

    invoke-static {v10}, Lcom/igg/util/DeviceUtil;->getFilterIMEI(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v1

    .line 510
    .local v1, "androidId":Ljava/lang/String;
    if-eqz v1, :cond_3

    const-string v10, ""

    invoke-virtual {v1, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_3

    .line 511
    const-string v10, "IGGSDK"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "Not Emulator-aid="

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 512
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "aid="

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 513
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "aid="

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 517
    :cond_3
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    invoke-static {v10}, Lcom/igg/sdk/IGGSDK;->access$000(Lcom/igg/sdk/IGGSDK;)Landroid/app/Application;

    move-result-object v10

    invoke-static {v10}, Lcom/igg/util/DeviceUtil;->getFilterLocalMacAddress(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v5

    .line 518
    .local v5, "macAdress":Ljava/lang/String;
    if-eqz v5, :cond_4

    const-string v10, ""

    invoke-virtual {v5, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_4

    .line 519
    if-eqz v1, :cond_6

    const-string v10, ""

    invoke-virtual {v1, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_6

    .line 520
    const-string v10, "IGGSDK"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "Not Emulator-mac="

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 521
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "mac="

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ",aid="

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 522
    .local v8, "str":Ljava/lang/String;
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-virtual {v10, v8}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 523
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    invoke-virtual {v10, v8}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 531
    .end local v8    # "str":Ljava/lang/String;
    :cond_4
    :goto_1
    new-instance v10, Lcom/igg/sdk/IGGSDK$1$1;

    invoke-direct {v10, p0, v5, v1}, Lcom/igg/sdk/IGGSDK$1$1;-><init>(Lcom/igg/sdk/IGGSDK$1;Ljava/lang/String;Ljava/lang/String;)V

    invoke-static {v10}, Lcom/igg/util/DeviceUtil;->getAdvertisingId(Lcom/igg/util/DeviceUtil$getAdvertisingIdListener;)V

    .line 557
    const-string v10, "IGGSDK"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, " first currentDeviceUID:"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    iget-object v12, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-virtual {v12}, Lcom/igg/sdk/IGGDeviceStorage;->currentDeviceUID()Ljava/lang/String;

    move-result-object v12

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 609
    .end local v1    # "androidId":Ljava/lang/String;
    .end local v5    # "macAdress":Ljava/lang/String;
    :cond_5
    :goto_2
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$listener:Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;

    invoke-interface {v10}, Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;->finish()V

    .line 610
    const-string v10, "IGGSDK"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, " two currentDeviceUID:"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    iget-object v12, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-virtual {v12}, Lcom/igg/sdk/IGGDeviceStorage;->currentDeviceUID()Ljava/lang/String;

    move-result-object v12

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 611
    const-string v10, "IGGSDK"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "FISRST IGGSDK.sharedInstance().getDeviceRegisterId():"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v12

    invoke-virtual {v12}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v12

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 525
    .restart local v1    # "androidId":Ljava/lang/String;
    .restart local v5    # "macAdress":Ljava/lang/String;
    :cond_6
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "mac="

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 526
    .restart local v8    # "str":Ljava/lang/String;
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-virtual {v10, v8}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 527
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    invoke-virtual {v10, v8}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    goto/16 :goto_1

    .line 559
    .end local v1    # "androidId":Ljava/lang/String;
    .end local v5    # "macAdress":Ljava/lang/String;
    .end local v8    # "str":Ljava/lang/String;
    :cond_7
    const-string v10, ""

    invoke-virtual {v7, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_8

    const-string v10, ","

    invoke-virtual {v7, v10}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v10

    const/4 v11, -0x1

    if-ne v10, v11, :cond_8

    const-string v10, "="

    invoke-virtual {v7, v10}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v10

    const/4 v11, -0x1

    if-ne v10, v11, :cond_8

    .line 560
    const-string v10, "mac="

    invoke-virtual {v7, v10}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v10

    const/4 v11, -0x1

    if-ne v10, v11, :cond_c

    .line 561
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "mac="

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    .line 562
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-virtual {v10, v7}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 568
    :goto_3
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    invoke-virtual {v10, v7}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 571
    :cond_8
    const-string v10, ""

    invoke-virtual {v7, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_5

    const-string v10, ","

    invoke-virtual {v7, v10}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v10

    const/4 v11, -0x1

    if-eq v10, v11, :cond_5

    const-string v10, "="

    invoke-virtual {v7, v10}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v10

    const/4 v11, -0x1

    if-eq v10, v11, :cond_5

    .line 572
    const-string v3, ""

    .line 573
    .local v3, "gaidStr":Ljava/lang/String;
    const-string v6, ""

    .line 574
    .local v6, "macStr":Ljava/lang/String;
    const-string v0, ""

    .line 575
    .local v0, "aidStr":Ljava/lang/String;
    const-string v10, ","

    invoke-virtual {v7, v10}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v2

    .line 576
    .local v2, "ary":[Ljava/lang/String;
    const/4 v4, 0x0

    .local v4, "i":I
    :goto_4
    array-length v10, v2

    if-ge v4, v10, :cond_d

    .line 577
    aget-object v10, v2, v4

    const-string v11, "="

    invoke-virtual {v10, v11}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v10

    const/4 v11, 0x0

    aget-object v10, v10, v11

    const-string v11, "gaid"

    invoke-virtual {v10, v11}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-eqz v10, :cond_9

    .line 578
    aget-object v3, v2, v4

    .line 581
    :cond_9
    aget-object v10, v2, v4

    const-string v11, "="

    invoke-virtual {v10, v11}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v10

    const/4 v11, 0x0

    aget-object v10, v10, v11

    const-string v11, "mac"

    invoke-virtual {v10, v11}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-eqz v10, :cond_a

    .line 582
    aget-object v10, v2, v4

    invoke-static {v10}, Lcom/igg/util/FilterMacAddress;->filterIsInvalidMacAdress(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 585
    :cond_a
    aget-object v10, v2, v4

    const-string v11, "="

    invoke-virtual {v10, v11}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v10

    const/4 v11, 0x0

    aget-object v10, v10, v11

    const-string v11, "aid"

    invoke-virtual {v10, v11}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-eqz v10, :cond_b

    .line 586
    aget-object v10, v2, v4

    invoke-static {v10}, Lcom/igg/util/FilterAndroidId;->filterIsInvalidAndroidId(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 576
    :cond_b
    add-int/lit8 v4, v4, 0x1

    goto :goto_4

    .line 564
    .end local v0    # "aidStr":Ljava/lang/String;
    .end local v2    # "ary":[Ljava/lang/String;
    .end local v3    # "gaidStr":Ljava/lang/String;
    .end local v4    # "i":I
    .end local v6    # "macStr":Ljava/lang/String;
    :cond_c
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "mac="

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, "mac="

    const-string v12, ""

    invoke-virtual {v7, v11, v12}, Ljava/lang/String;->replaceAll(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    .line 565
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-virtual {v10, v7}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    goto/16 :goto_3

    .line 590
    .restart local v0    # "aidStr":Ljava/lang/String;
    .restart local v2    # "ary":[Ljava/lang/String;
    .restart local v3    # "gaidStr":Ljava/lang/String;
    .restart local v4    # "i":I
    .restart local v6    # "macStr":Ljava/lang/String;
    :cond_d
    const-string v8, ""

    .line 591
    .restart local v8    # "str":Ljava/lang/String;
    const-string v10, ""

    invoke-virtual {v3, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_e

    .line 592
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v10, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ","

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 595
    :cond_e
    const-string v10, ""

    invoke-virtual {v6, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_f

    .line 596
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v10, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ","

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 599
    :cond_f
    const-string v10, ""

    invoke-virtual {v0, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_10

    .line 600
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v10, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ","

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 603
    :cond_10
    const/4 v10, 0x0

    invoke-virtual {v8}, Ljava/lang/String;->length()I

    move-result v11

    add-int/lit8 v11, v11, -0x1

    invoke-virtual {v8, v10, v11}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v8

    .line 604
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->val$deviceStorage:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-virtual {v10, v8}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 605
    iget-object v10, p0, Lcom/igg/sdk/IGGSDK$1;->this$0:Lcom/igg/sdk/IGGSDK;

    invoke-virtual {v10, v8}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    goto/16 :goto_2
.end method
