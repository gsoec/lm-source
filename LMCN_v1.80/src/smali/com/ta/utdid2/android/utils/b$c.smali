.class final Lcom/ta/utdid2/android/utils/b$c;
.super Lcom/ta/utdid2/android/utils/b$a;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/ta/utdid2/android/utils/b;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = "c"
.end annotation


# static fields
.field public static final c:I = 0x13

.field static final synthetic h:Z

.field private static final i:[B

.field private static final j:[B


# instance fields
.field d:I

.field public final e:Z

.field public final f:Z

.field public final g:Z

.field private final k:[B

.field private l:I

.field private final m:[B


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .prologue
    const/16 v1, 0x40

    .line 562
    const-class v0, Lcom/ta/utdid2/android/utils/b;

    invoke-virtual {v0}, Ljava/lang/Class;->desiredAssertionStatus()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    sput-boolean v0, Lcom/ta/utdid2/android/utils/b$c;->h:Z

    .line 574
    new-array v0, v1, [B

    fill-array-data v0, :array_0

    sput-object v0, Lcom/ta/utdid2/android/utils/b$c;->i:[B

    .line 585
    new-array v0, v1, [B

    fill-array-data v0, :array_1

    sput-object v0, Lcom/ta/utdid2/android/utils/b$c;->j:[B

    .line 590
    return-void

    .line 562
    :cond_0
    const/4 v0, 0x0

    goto :goto_0

    .line 574
    :array_0
    .array-data 1
        0x41t
        0x42t
        0x43t
        0x44t
        0x45t
        0x46t
        0x47t
        0x48t
        0x49t
        0x4at
        0x4bt
        0x4ct
        0x4dt
        0x4et
        0x4ft
        0x50t
        0x51t
        0x52t
        0x53t
        0x54t
        0x55t
        0x56t
        0x57t
        0x58t
        0x59t
        0x5at
        0x61t
        0x62t
        0x63t
        0x64t
        0x65t
        0x66t
        0x67t
        0x68t
        0x69t
        0x6at
        0x6bt
        0x6ct
        0x6dt
        0x6et
        0x6ft
        0x70t
        0x71t
        0x72t
        0x73t
        0x74t
        0x75t
        0x76t
        0x77t
        0x78t
        0x79t
        0x7at
        0x30t
        0x31t
        0x32t
        0x33t
        0x34t
        0x35t
        0x36t
        0x37t
        0x38t
        0x39t
        0x2bt
        0x2ft
    .end array-data

    .line 585
    :array_1
    .array-data 1
        0x41t
        0x42t
        0x43t
        0x44t
        0x45t
        0x46t
        0x47t
        0x48t
        0x49t
        0x4at
        0x4bt
        0x4ct
        0x4dt
        0x4et
        0x4ft
        0x50t
        0x51t
        0x52t
        0x53t
        0x54t
        0x55t
        0x56t
        0x57t
        0x58t
        0x59t
        0x5at
        0x61t
        0x62t
        0x63t
        0x64t
        0x65t
        0x66t
        0x67t
        0x68t
        0x69t
        0x6at
        0x6bt
        0x6ct
        0x6dt
        0x6et
        0x6ft
        0x70t
        0x71t
        0x72t
        0x73t
        0x74t
        0x75t
        0x76t
        0x77t
        0x78t
        0x79t
        0x7at
        0x30t
        0x31t
        0x32t
        0x33t
        0x34t
        0x35t
        0x36t
        0x37t
        0x38t
        0x39t
        0x2dt
        0x5ft
    .end array-data
.end method

.method public constructor <init>(I)V
    .locals 3

    .prologue
    const/4 v1, 0x1

    const/4 v2, 0x0

    .line 601
    invoke-direct {p0}, Lcom/ta/utdid2/android/utils/b$a;-><init>()V

    .line 602
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/ta/utdid2/android/utils/b$c;->a:[B

    .line 604
    and-int/lit8 v0, p1, 0x1

    if-nez v0, :cond_0

    move v0, v1

    :goto_0
    iput-boolean v0, p0, Lcom/ta/utdid2/android/utils/b$c;->e:Z

    .line 605
    and-int/lit8 v0, p1, 0x2

    if-nez v0, :cond_1

    move v0, v1

    :goto_1
    iput-boolean v0, p0, Lcom/ta/utdid2/android/utils/b$c;->f:Z

    .line 606
    and-int/lit8 v0, p1, 0x4

    if-eqz v0, :cond_2

    :goto_2
    iput-boolean v1, p0, Lcom/ta/utdid2/android/utils/b$c;->g:Z

    .line 607
    and-int/lit8 v0, p1, 0x8

    if-nez v0, :cond_3

    sget-object v0, Lcom/ta/utdid2/android/utils/b$c;->i:[B

    :goto_3
    iput-object v0, p0, Lcom/ta/utdid2/android/utils/b$c;->m:[B

    .line 609
    const/4 v0, 0x2

    new-array v0, v0, [B

    iput-object v0, p0, Lcom/ta/utdid2/android/utils/b$c;->k:[B

    .line 610
    iput v2, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    .line 612
    iget-boolean v0, p0, Lcom/ta/utdid2/android/utils/b$c;->f:Z

    if-eqz v0, :cond_4

    const/16 v0, 0x13

    :goto_4
    iput v0, p0, Lcom/ta/utdid2/android/utils/b$c;->l:I

    .line 613
    return-void

    :cond_0
    move v0, v2

    .line 604
    goto :goto_0

    :cond_1
    move v0, v2

    .line 605
    goto :goto_1

    :cond_2
    move v1, v2

    .line 606
    goto :goto_2

    .line 607
    :cond_3
    sget-object v0, Lcom/ta/utdid2/android/utils/b$c;->j:[B

    goto :goto_3

    .line 612
    :cond_4
    const/4 v0, -0x1

    goto :goto_4
.end method


# virtual methods
.method public final a(I)I
    .locals 1

    .prologue
    .line 620
    mul-int/lit8 v0, p1, 0x8

    div-int/lit8 v0, v0, 0x5

    add-int/lit8 v0, v0, 0xa

    return v0
.end method

.method public final a([BII)Z
    .locals 10

    .prologue
    .line 625
    iget-object v6, p0, Lcom/ta/utdid2/android/utils/b$c;->m:[B

    .line 626
    iget-object v7, p0, Lcom/ta/utdid2/android/utils/b$c;->a:[B

    .line 627
    const/4 v4, 0x0

    .line 628
    iget v1, p0, Lcom/ta/utdid2/android/utils/b$c;->l:I

    .line 631
    add-int v8, p3, p2

    .line 632
    const/4 v0, -0x1

    .line 638
    iget v2, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    packed-switch v2, :pswitch_data_0

    :cond_0
    move v2, p2

    move v3, v0

    .line 664
    :goto_0
    const/4 v0, -0x1

    if-eq v3, v0, :cond_14

    .line 665
    const/4 v0, 0x0

    shr-int/lit8 v4, v3, 0x12

    and-int/lit8 v4, v4, 0x3f

    aget-byte v4, v6, v4

    aput-byte v4, v7, v0

    .line 666
    const/4 v0, 0x1

    shr-int/lit8 v4, v3, 0xc

    and-int/lit8 v4, v4, 0x3f

    aget-byte v4, v6, v4

    aput-byte v4, v7, v0

    .line 667
    const/4 v0, 0x2

    shr-int/lit8 v4, v3, 0x6

    and-int/lit8 v4, v4, 0x3f

    aget-byte v4, v6, v4

    aput-byte v4, v7, v0

    .line 668
    const/4 v4, 0x3

    const/4 v0, 0x4

    and-int/lit8 v3, v3, 0x3f

    aget-byte v3, v6, v3

    aput-byte v3, v7, v4

    .line 669
    add-int/lit8 v1, v1, -0x1

    if-nez v1, :cond_13

    .line 670
    iget-boolean v1, p0, Lcom/ta/utdid2/android/utils/b$c;->g:Z

    if-eqz v1, :cond_1

    .line 671
    const/4 v1, 0x4

    const/4 v0, 0x5

    const/16 v3, 0xd

    aput-byte v3, v7, v1

    .line 672
    :cond_1
    add-int/lit8 v4, v0, 0x1

    const/16 v1, 0xa

    aput-byte v1, v7, v0

    .line 673
    const/16 v0, 0x13

    move v5, v0

    .line 682
    :goto_1
    add-int/lit8 v0, v2, 0x3

    if-le v0, v8, :cond_5

    .line 705
    iget v0, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    sub-int v0, v2, v0

    add-int/lit8 v1, v8, -0x1

    if-ne v0, v1, :cond_7

    .line 706
    const/4 v1, 0x0

    .line 707
    iget v0, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    if-lez v0, :cond_6

    iget-object v0, p0, Lcom/ta/utdid2/android/utils/b$c;->k:[B

    const/4 v3, 0x0

    const/4 v1, 0x1

    aget-byte v0, v0, v3

    :goto_2
    and-int/lit16 v0, v0, 0xff

    shl-int/lit8 v3, v0, 0x4

    .line 708
    iget v0, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    sub-int/2addr v0, v1

    iput v0, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    .line 709
    add-int/lit8 v1, v4, 0x1

    shr-int/lit8 v0, v3, 0x6

    and-int/lit8 v0, v0, 0x3f

    aget-byte v0, v6, v0

    aput-byte v0, v7, v4

    .line 710
    add-int/lit8 v0, v1, 0x1

    and-int/lit8 v3, v3, 0x3f

    aget-byte v3, v6, v3

    aput-byte v3, v7, v1

    .line 711
    iget-boolean v1, p0, Lcom/ta/utdid2/android/utils/b$c;->e:Z

    if-eqz v1, :cond_2

    .line 712
    add-int/lit8 v1, v0, 0x1

    const/16 v3, 0x3d

    aput-byte v3, v7, v0

    .line 713
    add-int/lit8 v0, v1, 0x1

    const/16 v3, 0x3d

    aput-byte v3, v7, v1

    .line 715
    :cond_2
    iget-boolean v1, p0, Lcom/ta/utdid2/android/utils/b$c;->f:Z

    if-eqz v1, :cond_f

    .line 716
    iget-boolean v1, p0, Lcom/ta/utdid2/android/utils/b$c;->g:Z

    if-eqz v1, :cond_3

    .line 717
    add-int/lit8 v1, v0, 0x1

    const/16 v3, 0xd

    aput-byte v3, v7, v0

    move v0, v1

    .line 718
    :cond_3
    add-int/lit8 v4, v0, 0x1

    const/16 v1, 0xa

    aput-byte v1, v7, v0

    .line 742
    :cond_4
    :goto_3
    sget-boolean v0, Lcom/ta/utdid2/android/utils/b$c;->h:Z

    if-nez v0, :cond_c

    iget v0, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    if-eqz v0, :cond_c

    new-instance v0, Ljava/lang/AssertionError;

    invoke-direct {v0}, Ljava/lang/AssertionError;-><init>()V

    throw v0

    :pswitch_0
    move v2, p2

    move v3, v0

    .line 641
    goto/16 :goto_0

    .line 644
    :pswitch_1
    add-int/lit8 v2, p2, 0x2

    if-gt v2, v8, :cond_0

    .line 647
    iget-object v0, p0, Lcom/ta/utdid2/android/utils/b$c;->k:[B

    const/4 v2, 0x0

    aget-byte v0, v0, v2

    and-int/lit16 v0, v0, 0xff

    shl-int/lit8 v0, v0, 0x10

    add-int/lit8 v2, p2, 0x1

    aget-byte v3, p1, p2

    and-int/lit16 v3, v3, 0xff

    shl-int/lit8 v3, v3, 0x8

    or-int/2addr v0, v3

    .line 648
    add-int/lit8 p2, v2, 0x1

    aget-byte v2, p1, v2

    and-int/lit16 v2, v2, 0xff

    .line 647
    or-int/2addr v0, v2

    .line 649
    const/4 v2, 0x0

    iput v2, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    move v2, p2

    move v3, v0

    .line 652
    goto/16 :goto_0

    .line 655
    :pswitch_2
    add-int/lit8 v2, p2, 0x1

    if-gt v2, v8, :cond_0

    .line 657
    iget-object v0, p0, Lcom/ta/utdid2/android/utils/b$c;->k:[B

    const/4 v2, 0x0

    aget-byte v0, v0, v2

    and-int/lit16 v0, v0, 0xff

    shl-int/lit8 v0, v0, 0x10

    iget-object v2, p0, Lcom/ta/utdid2/android/utils/b$c;->k:[B

    const/4 v3, 0x1

    aget-byte v2, v2, v3

    and-int/lit16 v2, v2, 0xff

    shl-int/lit8 v2, v2, 0x8

    or-int/2addr v0, v2

    .line 658
    add-int/lit8 v2, p2, 0x1

    aget-byte v3, p1, p2

    and-int/lit16 v3, v3, 0xff

    .line 657
    or-int/2addr v0, v3

    .line 659
    const/4 v3, 0x0

    iput v3, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    move v3, v0

    goto/16 :goto_0

    .line 683
    :cond_5
    aget-byte v0, p1, v2

    and-int/lit16 v0, v0, 0xff

    shl-int/lit8 v0, v0, 0x10

    add-int/lit8 v1, v2, 0x1

    aget-byte v1, p1, v1

    and-int/lit16 v1, v1, 0xff

    shl-int/lit8 v1, v1, 0x8

    or-int/2addr v0, v1

    .line 684
    add-int/lit8 v1, v2, 0x2

    aget-byte v1, p1, v1

    and-int/lit16 v1, v1, 0xff

    .line 683
    or-int/2addr v0, v1

    .line 685
    shr-int/lit8 v1, v0, 0x12

    and-int/lit8 v1, v1, 0x3f

    aget-byte v1, v6, v1

    aput-byte v1, v7, v4

    .line 686
    add-int/lit8 v1, v4, 0x1

    shr-int/lit8 v3, v0, 0xc

    and-int/lit8 v3, v3, 0x3f

    aget-byte v3, v6, v3

    aput-byte v3, v7, v1

    .line 687
    add-int/lit8 v1, v4, 0x2

    shr-int/lit8 v3, v0, 0x6

    and-int/lit8 v3, v3, 0x3f

    aget-byte v3, v6, v3

    aput-byte v3, v7, v1

    .line 688
    add-int/lit8 v1, v4, 0x3

    and-int/lit8 v0, v0, 0x3f

    aget-byte v0, v6, v0

    aput-byte v0, v7, v1

    .line 689
    add-int/lit8 v2, v2, 0x3

    .line 690
    add-int/lit8 v1, v4, 0x4

    .line 691
    add-int/lit8 v0, v5, -0x1

    if-nez v0, :cond_12

    .line 692
    iget-boolean v0, p0, Lcom/ta/utdid2/android/utils/b$c;->g:Z

    if-eqz v0, :cond_11

    .line 693
    add-int/lit8 v0, v1, 0x1

    const/16 v3, 0xd

    aput-byte v3, v7, v1

    .line 694
    :goto_4
    add-int/lit8 v4, v0, 0x1

    const/16 v1, 0xa

    aput-byte v1, v7, v0

    .line 695
    const/16 v0, 0x13

    move v5, v0

    goto/16 :goto_1

    .line 707
    :cond_6
    add-int/lit8 v3, v2, 0x1

    aget-byte v0, p1, v2

    move v2, v3

    goto/16 :goto_2

    .line 720
    :cond_7
    iget v0, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    sub-int v0, v2, v0

    add-int/lit8 v1, v8, -0x2

    if-ne v0, v1, :cond_b

    .line 721
    const/4 v1, 0x0

    .line 722
    iget v0, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    const/4 v3, 0x1

    if-le v0, v3, :cond_9

    iget-object v0, p0, Lcom/ta/utdid2/android/utils/b$c;->k:[B

    const/4 v3, 0x0

    const/4 v1, 0x1

    aget-byte v0, v0, v3

    :goto_5
    and-int/lit16 v0, v0, 0xff

    shl-int/lit8 v9, v0, 0xa

    .line 723
    iget v0, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    if-lez v0, :cond_a

    iget-object v0, p0, Lcom/ta/utdid2/android/utils/b$c;->k:[B

    add-int/lit8 v3, v1, 0x1

    aget-byte v0, v0, v1

    move v1, v3

    :goto_6
    and-int/lit16 v0, v0, 0xff

    shl-int/lit8 v0, v0, 0x2

    .line 722
    or-int/2addr v0, v9

    .line 724
    iget v3, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    sub-int v1, v3, v1

    iput v1, p0, Lcom/ta/utdid2/android/utils/b$c;->d:I

    .line 725
    add-int/lit8 v1, v4, 0x1

    shr-int/lit8 v3, v0, 0xc

    and-int/lit8 v3, v3, 0x3f

    aget-byte v3, v6, v3

    aput-byte v3, v7, v4

    .line 726
    add-int/lit8 v3, v1, 0x1

    shr-int/lit8 v4, v0, 0x6

    and-int/lit8 v4, v4, 0x3f

    aget-byte v4, v6, v4

    aput-byte v4, v7, v1

    .line 727
    add-int/lit8 v1, v3, 0x1

    and-int/lit8 v0, v0, 0x3f

    aget-byte v0, v6, v0

    aput-byte v0, v7, v3

    .line 728
    iget-boolean v0, p0, Lcom/ta/utdid2/android/utils/b$c;->e:Z

    if-eqz v0, :cond_10

    .line 729
    add-int/lit8 v0, v1, 0x1

    const/16 v3, 0x3d

    aput-byte v3, v7, v1

    .line 731
    :goto_7
    iget-boolean v1, p0, Lcom/ta/utdid2/android/utils/b$c;->f:Z

    if-eqz v1, :cond_f

    .line 732
    iget-boolean v1, p0, Lcom/ta/utdid2/android/utils/b$c;->g:Z

    if-eqz v1, :cond_8

    .line 733
    add-int/lit8 v1, v0, 0x1

    const/16 v3, 0xd

    aput-byte v3, v7, v0

    move v0, v1

    .line 734
    :cond_8
    add-int/lit8 v4, v0, 0x1

    const/16 v1, 0xa

    aput-byte v1, v7, v0

    goto/16 :goto_3

    .line 722
    :cond_9
    add-int/lit8 v3, v2, 0x1

    aget-byte v0, p1, v2

    move v2, v3

    goto :goto_5

    .line 723
    :cond_a
    add-int/lit8 v3, v2, 0x1

    aget-byte v0, p1, v2

    move v2, v3

    goto :goto_6

    .line 736
    :cond_b
    iget-boolean v0, p0, Lcom/ta/utdid2/android/utils/b$c;->f:Z

    if-eqz v0, :cond_4

    if-lez v4, :cond_4

    const/16 v0, 0x13

    if-eq v5, v0, :cond_4

    .line 737
    iget-boolean v0, p0, Lcom/ta/utdid2/android/utils/b$c;->g:Z

    if-eqz v0, :cond_e

    .line 738
    add-int/lit8 v0, v4, 0x1

    const/16 v1, 0xd

    aput-byte v1, v7, v4

    .line 739
    :goto_8
    add-int/lit8 v4, v0, 0x1

    const/16 v1, 0xa

    aput-byte v1, v7, v0

    goto/16 :goto_3

    .line 743
    :cond_c
    sget-boolean v0, Lcom/ta/utdid2/android/utils/b$c;->h:Z

    if-nez v0, :cond_d

    if-eq v2, v8, :cond_d

    new-instance v0, Ljava/lang/AssertionError;

    invoke-direct {v0}, Ljava/lang/AssertionError;-><init>()V

    throw v0

    .line 756
    :cond_d
    iput v4, p0, Lcom/ta/utdid2/android/utils/b$c;->b:I

    .line 757
    iput v5, p0, Lcom/ta/utdid2/android/utils/b$c;->l:I

    .line 759
    const/4 v0, 0x1

    return v0

    :cond_e
    move v0, v4

    goto :goto_8

    :cond_f
    move v4, v0

    goto/16 :goto_3

    :cond_10
    move v0, v1

    goto :goto_7

    :cond_11
    move v0, v1

    goto/16 :goto_4

    :cond_12
    move v5, v0

    move v4, v1

    goto/16 :goto_1

    :cond_13
    move v5, v1

    move v4, v0

    goto/16 :goto_1

    :cond_14
    move v5, v1

    goto/16 :goto_1

    .line 638
    nop

    :pswitch_data_0
    .packed-switch 0x0
        :pswitch_0
        :pswitch_1
        :pswitch_2
    .end packed-switch
.end method
